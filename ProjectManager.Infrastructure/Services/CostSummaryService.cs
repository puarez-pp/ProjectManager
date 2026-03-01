using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Queries.GetCostSummary;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Services;

public class CostSummaryService : ICostSummaryService
{
    private readonly IFinanceService _financeService;

    public CostSummaryService(
        IFinanceService financeService)
    {
        _financeService = financeService;
    }
    public IReadOnlyCollection<ScopeCostSummaryDto> Calculate(
        IReadOnlyCollection<WorkScopeOfferCostBase> offers, 
        IReadOnlyCollection<WorkScopeOfferCostBase> costs, 
        decimal marginGen, decimal marginInst)
    {
        var workScopeIds = offers.Select(x => x.WorkScopeId)
            .Union(costs.Select(x => x.WorkScopeId))
            .Distinct()
            .ToList();

        var result = new List<ScopeCostSummaryDto>();

        foreach (var id in workScopeIds)
        {
            var offer = offers.FirstOrDefault(x => x.WorkScopeId == id);
            var cost = costs.FirstOrDefault(x => x.WorkScopeId == id);

            var type = offer?.WorkScopeType ?? cost!.WorkScopeType;
            var description = offer?.Description ?? cost!.Description;
            var order = offer?.Order ?? cost!.Order;

            var margin = type == WorkScopeType.Agregat ? marginGen : marginInst;

            var offerAmount = offer != null
                ? _financeService.ApplyMargin(offer.SumNet, margin)
                : 0m;

            var costAmount = cost != null
                ? _financeService.RoundAmount(cost.SumNet)
                : 0m;

            result.Add(new ScopeCostSummaryDto
            {
                Id = id,
                WorkScopeType = type,
                Description = description,
                Offer = offerAmount,
                Cost = costAmount,
                Profit = offerAmount - costAmount
            });
        }

        return result
            .OrderBy(x => x.Id)
            .ThenBy(x => x.Description)
            .ToList();
    }
}

