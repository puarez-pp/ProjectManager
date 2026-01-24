using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetCostSummary;

public class GetCostSummaryQueryHandler : IRequestHandler<GetCostSummaryQuery, CostSummaryVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IFinanceService _financeService;

    public GetCostSummaryQueryHandler(
        IApplicationDbContext context,
        IFinanceService financeService)
    {
        _context = context;
        _financeService = financeService;
    }
    public async Task<CostSummaryVm> Handle(GetCostSummaryQuery request, CancellationToken cancellationToken)
    {
        var margins = await _context
            .Assumptions
            .AsNoTracking()
            .Where(x => x.SettlementId == request.Id)
            .Select(x => new {marginGen = x.MarginGen, marginInst = x.MarginInstall })
            .FirstOrDefaultAsync();

        var settlement = await _context
            .WorkScopes
            .AsNoTracking()
            .Where(x => x.SettlementId == request.Id)
            .GroupBy(g => new { g.Id })
            .Select(x => new ScopeCostSummaryDto
            {
                Id = x.Key.Id,
                Description = x.First().Description,
                Offer = x.Sum(g => g.WorkScopeOffers.Sum(s => _financeService.ApplyMargin(s.Quantity * s.NetAmount, g.WorkScopeType == WorkScopeType.Agregat ? margins.marginGen : margins.marginInst))),
                Cost = x.Sum(g => g.WorkScopeCosts.Sum(s => _financeService.RoundAmount(s.Quantity * s.NetAmount))),
                Profit = x.Sum(g => g.WorkScopeOffers.Sum(s => _financeService.ApplyMargin(s.Quantity * s.NetAmount, g.WorkScopeType == WorkScopeType.Agregat ? margins.marginGen : margins.marginInst))) - x.Sum(g => g.WorkScopeCosts.Sum(s => _financeService.RoundAmount(s.Quantity * s.NetAmount)))
            })
            .OrderBy(x=>x.Id)
            .ToListAsync();
        var vm = new CostSummaryVm
        {
            Offers = _financeService.CalculateSumAmounts(settlement.Select(x => x.Offer)),
            Costs = _financeService.CalculateSumAmounts(settlement.Select(x => x.Cost)),
            Profits = _financeService.CalculateSumAmounts(settlement.Select(x => x.Profit)),
            ScopeCosts = settlement
        };
        return vm;
    }
}
