using ProjectManager.Application.Settlements.Queries.GetAssumptions;
using ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Extensions;

public static class SettlementExtensions
{
    public static AssumptionDto ToAssumptionsDto(this Assumption assumption)
    {
        if (assumption == null)
        {
            return null;
        }
        return new AssumptionDto
        {
            Id = assumption.Id,
            MarginGen = assumption.MarginGen,
            MarginInstall = assumption.MarginInstall,
            Discount = assumption.Discount,
            Maturity = assumption.Maturity,
            CompanyCost = assumption.CompanyCost,
            CompanyGuarantee = assumption.CompanyGuarantee,
            Insurance = assumption.Insurance
        };
    }

    public static WorkScopeOfferDto ToWorkScopeOfferDto(this WorkScopeOffer offer)
    {
        if (offer == null)
        {
            return null;
        }
        return new WorkScopeOfferDto
        {
            Id = offer.Id,
            Description = offer.Description,
            Order = offer.Order,
            IsUsed = offer.IsUsed,
            UnitType = offer.UnitType,
            Quantity = offer.Quantity,
            NetAmount = offer.NetAmount,
            SubContractor = offer.SubContractor.Name,
        };
    }

    public static WorkScopeCostDto ToWorkScopeCostDto(this WorkScopeCost cost)
    {
        if (cost == null)
        {
            return null;
        }
        return new WorkScopeCostDto
        {
            Id = cost.Id,
            Description = cost.Description,
            Order = cost.Order,
            UnitType = cost.UnitType,
            CostStatusType = cost.CostStatusType,
            Quantity = cost.Quantity,
            NetAmount = cost.NetAmount,
            SubContractor = cost.SubContractor.Name,
        };
    }
    public static WorkScopeDto ToWorkScopeDto(this WorkScope scope)
    {
        if (scope == null)
        {
            return null;
        }
        return new WorkScopeDto
        {
            Id = scope.Id,
            Description = scope.Description,
            Order = scope.Order,
            WorkScopeType = scope.WorkScopeType,
        };
    }

}
