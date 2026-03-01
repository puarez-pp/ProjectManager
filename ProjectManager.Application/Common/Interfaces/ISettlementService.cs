using ProjectManager.Application.Settlements.Queries.GetAssumption;
using ProjectManager.Application.Settlements.Queries.GetCostDetails;
using ProjectManager.Application.Settlements.Queries.GetCostSummary;
using ProjectManager.Application.Settlements.Queries.GetFinancialControl;
using ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;

namespace ProjectManager.Application.Settlements.Calculations;

public interface ISettlementService
{
    WorkScopeSumDto CalculateAssumptionsSummary(
        AssumptionDto assumption,
        IReadOnlyCollection<WorkScopeBaseAmount> offersBase,
        IReadOnlyCollection<WorkScopeBaseAmount> costsBase);

    IReadOnlyCollection<ScopeCostSummaryDto> CalculateCostSummary(
        IReadOnlyCollection<WorkScopeOfferCostBase> offers,
        IReadOnlyCollection<WorkScopeOfferCostBase> costs,
        decimal marginGen,
        decimal marginInst);

    IReadOnlyCollection<WorkScopeDto> CalculateCostDetails(
        IReadOnlyCollection<RawWorkScopeCost> rawScopes);

    IReadOnlyCollection<WorkScopeDto> CalculateScopeTypeOffer(
        IReadOnlyCollection<RawWorkScopeOffer> rawScopes,
        decimal margin);

    FinancialControlResult CalculateFinancialControl(
        IReadOnlyCollection<RawFinancialControlScope> scopes);
}



