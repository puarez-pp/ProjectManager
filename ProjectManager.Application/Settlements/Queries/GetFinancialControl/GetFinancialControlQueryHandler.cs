using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
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

        var invoices = await _context
            .Invoices
            .AsNoTracking()
            .Where(x => x.SettlementId == request.Id)
            .Select(x => new InvoiceDto
            {
                Id = x.Id,
                Number = x.Number,
                IssueDate = x.IssueDate,
                NetAmount = x.NetAmount,
                EuroNetAmount = x.EuroNetAmount,
                EuroRate = x.EuroRate,
                OrderNumber = x.OrderNumber,
                Vendor = x.Vendor.Name,
                ScopeDescription = x.WorkScope.Description

            })
            .ToListAsync();

        var totalSums = await _context
            .WorkScopes
            .AsNoTracking()
            .Where(x => x.SettlementId == request.Id)
            .GroupBy(g => new { g.Id, g.Description })
            .Select(x => new InvoiceSumDto
            {
                Id = x.Key.Id,
                Description = x.Key.Description,
                Total = _financeService.RoundAmount(x.Sum(y => y.Invoices.Sum(x => x.NetAmount)))
            })
            .OrderBy(g=>g.Id)
            .ToListAsync();

        var vm = new FinancialControlVm()
        {
            Invoices = invoices,
            TotalSums = totalSums,
        };
        return vm;

    }
}
