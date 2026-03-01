using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Calculations;
using ProjectManager.Application.Settlements.Queries.GetAssumption;
using ProjectManager.Application.Settlements.Queries.GetCostDetails;
using ProjectManager.Application.Settlements.Queries.GetCostSummary;
using ProjectManager.Application.Settlements.Queries.GetFinancialControl;
using ProjectManager.Application.Settlements.Queries.GetInvoices;
using ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Services;

public class SettlementService : ISettlementService
{
    private readonly IFinanceService _financeService;

    public SettlementService(
        IFinanceService finance)
    {
        _financeService = finance;
    }

    public WorkScopeSumDto CalculateAssumptionsSummary(
        AssumptionDto assumption, 
        IReadOnlyCollection<WorkScopeBaseAmount> offersBase, 
        IReadOnlyCollection<WorkScopeBaseAmount> costsBase)
    {
        var sales = offersBase.Select(x =>
        {
            var margin = x.WorkScopeType == WorkScopeType.Agregat
                ? assumption.MarginGen
                : assumption.MarginInstall;

            return new WorkScopeSettl
            {
                ScopeType = x.WorkScopeType,
                ScopeAmount = _financeService.ApplyMargin(x.TotalBase, margin)
            };
        }).ToList();

        var costs = costsBase.Select(x => new WorkScopeSettl
        {
            ScopeType = x.WorkScopeType,
            ScopeAmount = _financeService.RoundAmount(x.TotalBase)
        }).ToList();

        var totalSales = sales.Sum(s => s.ScopeAmount);
        var totalImplementation = costs.Sum(s => s.ScopeAmount);

        var rates = new[] { assumption.CompanyCost, assumption.CompanyGuarantee, assumption.Insurance };
        var totalOverheads = _financeService.CalculatePercentageOfRates(totalImplementation, rates);

        var totalAfterDiscount =
            _financeService.ApplyDiscount(totalImplementation, assumption.Discount)
            + totalOverheads;

        return new WorkScopeSumDto
        {
            TotalSales = totalSales,
            TotalImplementation = totalImplementation,
            TotalOverheads = totalOverheads,
            TotalCosts = totalImplementation + totalOverheads,
            TotalAfterDiscount = totalAfterDiscount,
            Margin = _financeService.CalculateMarginRate(totalImplementation + totalOverheads, totalSales),
            FinalMargin = _financeService.CalculateMarginRate(totalAfterDiscount, totalSales),
            FinalProfit = _financeService.CalculateDifferenceAmounts(totalSales, totalAfterDiscount),
            Sales = sales,
            Costs = costs
        };
    }

    public IReadOnlyCollection<WorkScopeDto> CalculateCostDetails(
        IReadOnlyCollection<RawWorkScopeCost> rawScopes)
    {
        return rawScopes.Select(s =>
        {
            var costs = s.Costs.Select(o => new WorkScopeCostDto
            {
                Id = o.Id,
                Description = o.Description,
                CostStatusType = o.CostStatusType,
                Order = o.Order,
                UnitType = o.UnitType,
                Quantity = o.Quantity,
                NetAmount = o.NetAmount,
                Total = _financeService.RoundAmount(o.Quantity * o.NetAmount),
                SubContractor = o.SubContractor
            }).ToList();

            return new WorkScopeDto
            {
                Id = s.Id,
                Description = s.Description,
                Order = s.Order,
                Costs = costs,
                Total = costs.Sum(x => x.Total)
            };
        })
        .OrderBy(x => x.Order)
        .ToList();
    }

    public IReadOnlyCollection<ScopeCostSummaryDto> CalculateCostSummary(
        IReadOnlyCollection<WorkScopeOfferCostBase> offers, 
        IReadOnlyCollection<WorkScopeOfferCostBase> costs, 
        decimal marginGen, decimal marginInst)
    {
        var ids = offers.Select(x => x.WorkScopeId)
            .Union(costs.Select(x => x.WorkScopeId))
            .Distinct()
            .ToList();

        return ids.Select(id =>
        {
            var offer = offers.FirstOrDefault(x => x.WorkScopeId == id);
            var cost = costs.FirstOrDefault(x => x.WorkScopeId == id);

            var type = offer?.WorkScopeType ?? cost!.WorkScopeType;
            var margin = type == WorkScopeType.Agregat ? marginGen : marginInst;

            var offerAmount = offer != null
                ? _financeService.ApplyMargin(offer.SumNet, margin)
                : 0m;

            var costAmount = cost != null
                ? _financeService.RoundAmount(cost.SumNet)
                : 0m;

            return new ScopeCostSummaryDto
            {
                Id = id,
                WorkScopeType = type,
                Description = offer?.Description ?? cost!.Description,
                Offer = offerAmount,
                Cost = costAmount,
                Profit = offerAmount - costAmount
            };
        })
        .OrderBy(x => x.Id)
        .ThenBy(x => x.Description)
        .ToList();
    }

    public FinancialControlResult CalculateFinancialControl(IReadOnlyCollection<RawFinancialControlScope> scopes)
    {
        var invoiceSums = scopes
            .Select(s => new InvoiceSumDto
            {
                Id = s.Id,
                Description = s.Description,
                Total = _financeService.RoundAmount(s.Invoices.Sum(i => i.NetAmount))
            })
            .ToList();

        var allInvoices = scopes
            .SelectMany(s => s.Invoices)
            .OrderByDescending(i => i.IssueDate)
            .ThenByDescending(i => i.Id)
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
                ScopeDescription = i.ScopeDescription
            })
            .ToList();

        var totalSum = _financeService.RoundAmount(
            scopes.Sum(s => s.Invoices.Sum(i => i.NetAmount))
        );

        return new FinancialControlResult
        {
            TotalSums = invoiceSums,
            Invoices = allInvoices,
            TotalSum = totalSum
        };
    }

    public IReadOnlyCollection<WorkScopeDto> CalculateScopeTypeOffer(
        IReadOnlyCollection<RawWorkScopeOffer> rawScopes, 
        decimal margin)
    {
        return rawScopes.Select(s =>
        {
            var offers = s.Offers.Select(o => new WorkScopeOfferDto
            {
                Id = o.Id,
                Description = o.Description,
                Order = o.Order,
                IsUsed = o.IsUsed,
                UnitType = o.UnitType,
                Quantity = o.Quantity,
                NetAmount = o.NetAmount,
                Total = _financeService.ApplyMargin(o.Quantity * o.NetAmount, margin),
                SubContractor = o.SubContractor
            }).ToList();

            return new WorkScopeDto
            {
                Id = s.Id,
                Description = s.Description,
                Order = s.Order,
                Offers = offers,
                Total = offers.Sum(x => x.Total)
            };
        })
        .OrderBy(x => x.Order)
        .ToList();
    }
}


