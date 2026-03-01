using ProjectManager.Application.Settlements.Queries.GetCostSummary;

namespace ProjectManager.Application.Common.Interfaces;

public interface ICostSummaryService
{
    IReadOnlyCollection<ScopeCostSummaryDto> Calculate(
        IReadOnlyCollection<WorkScopeOfferCostBase> offers, 
        IReadOnlyCollection<WorkScopeOfferCostBase> costs, 
        decimal marginGen, 
        decimal marginInst);
}
