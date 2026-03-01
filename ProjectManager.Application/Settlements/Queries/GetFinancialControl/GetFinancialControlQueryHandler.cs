using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Calculations;
using ProjectManager.Application.Settlements.Queries.GetFinancialControl;

public class GetFinancialControlQueryHandler : IRequestHandler<GetFinancialControlQuery, FinancialControlVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ISettlementService _calc;

    public GetFinancialControlQueryHandler(
        IApplicationDbContext context,
        ISettlementService calc)
    {
        _context = context;
        _calc = calc;
    }

    public async Task<FinancialControlVm> Handle(GetFinancialControlQuery request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(x => new ProjectBasicsDto
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number
            })
            .FirstOrDefaultAsync(cancellationToken);

        var rawScopes = await _context.WorkScopes
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id)
            .Select(ws => new RawFinancialControlScope
            {
                Id = ws.Id,
                Description = ws.Description,
                Order = ws.Order,
                Invoices = ws.Invoices.Select(i => new RawInvoiceItem
                {
                    Id = i.Id,
                    Number = i.Number,
                    IssueDate = i.IssueDate,
                    NetAmount = i.NetAmount,
                    EuroNetAmount = i.EuroNetAmount,
                    EuroRate = i.EuroRate,
                    OrderNumber = i.OrderNumber,
                    Vendor = i.Vendor,
                    ScopeDescription = ws.Description
                }).ToList()
            })
            .OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);

        var result = _calc.CalculateFinancialControl(rawScopes);

        return new FinancialControlVm
        {
            Project = project,
            TotalSums = result.TotalSums.ToList(),
            Invoices = result.Invoices.ToList(),
            TotalSum = result.TotalSum
        };
    }
}
