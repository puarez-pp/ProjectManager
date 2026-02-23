using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Queries.GetAssumption;
using ProjectManager.Application.Settlements.Queries.GetInvoices;

namespace ProjectManager.Application.Settlements.Queries.GetFinancialControl;

public class GetFinancialControlQueryHandler : IRequestHandler<GetFinancialControlQuery, FinancialControlVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IFinanceService _financeService;

    public GetFinancialControlQueryHandler(
        IApplicationDbContext context,
        IFinanceService financeService)
    {
        _context = context;
        _financeService = financeService;
    }
    public async Task<FinancialControlVm> Handle(GetFinancialControlQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(x => new ProjectBasicsDto
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
            })
            .FirstOrDefaultAsync(cancellationToken);

        var settlement = await _context
            .Settlements
            .AsNoTracking()
            .Where(x => x.ProjectId== request.Id)
            .Select(s => new SettlementDto
            {
                Id = s.Id,
                WorkScopes = s.WorkScopes
                .OrderBy(ws => ws.Order)
                .Select(ws => new WorkScopeDto
                {
                    Id = ws.Id,
                    Description = ws.Description,
                    WorkScopeType = ws.WorkScopeType,
                    Order = ws.Order,
                    Invoices = ws.Invoices
                    .Select(i => new InvoiceDto
                    {
                        Id = i.Id,
                        Number = i.Number,
                        IssueDate = i.IssueDate,
                        NetAmount = i.NetAmount,
                        EuroNetAmount = i.EuroNetAmount,
                        EuroRate = i.EuroRate,
                        OrderNumber = i.OrderNumber,
                        Vendor = i.Vendor,
                        ScopeDescription = i.WorkScope.Description
                    }).ToList()
                }).ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        var workScopeSum = settlement.WorkScopes
            .GroupBy(g => g.Id)
            .Select(s => new InvoiceSumDto
            {
                Id = s.Key,
                Description = s.First().Description,
                Total = _financeService.RoundAmount(s.Sum(g => g.Invoices.Sum(i => i.NetAmount))),
            }).ToList();

        var vm = new FinancialControlVm()
        {
            Project = project,
            TotalSums = workScopeSum,
            Invoices = settlement.WorkScopes
            .SelectMany(ws => ws.Invoices)
            .OrderByDescending(i => i.IssueDate)
            .ThenByDescending(i => i.Id)
            .ToList(),
            TotalSum = _financeService.RoundAmount(settlement.WorkScopes.Sum(ws => ws.Invoices.Sum(i => i.NetAmount)))
        };
        return vm;

    }
}
