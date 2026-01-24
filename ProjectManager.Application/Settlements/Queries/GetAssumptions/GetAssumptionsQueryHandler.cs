using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Extensions;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetAssumptions;

public class GetAssumptionsQueryHandler : IRequestHandler<GetAssumptionsQuery, AssumptionsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IFinanceService _financeService;

    public GetAssumptionsQueryHandler(
        IApplicationDbContext context,
        IFinanceService financeService)
    {
        _context = context;
        _financeService = financeService;
    }
    public async Task<AssumptionsVm> Handle(GetAssumptionsQuery request, CancellationToken cancellationToken)
    {
        var settlement = await _context
            .WorkScopes
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id)
            .Include(x => x.WorkScopeOffers)
            .Include(x => x.WorkScopeCosts)
            .ToListAsync();


        var assumption = await _context
            .Assumptions
            .AsNoTracking()
            .Select(x=>x.ToAssumptionsDto())
            .FirstOrDefaultAsync();


         
        var offers = settlement
            .Select(x=>x)
            .GroupBy(g => g.WorkScopeType)
            .Select(x => new
            {
                WorkScopeType = x.Key,
                Total = x.Sum(g=>g.WorkScopeOffers.Sum(s=>_financeService.ApplyMargin(s.Quantity * s.NetAmount, x.Key == WorkScopeType.Agregat ? assumption.MarginGen : assumption.MarginInstall))),
            }).ToList();

        var costs = settlement
            .Select(x => x)
            .GroupBy(g => g.WorkScopeType)
            .Select(x => new
            {
                WorkScopeType = x.Key,
                Total = x.Sum(y => y.WorkScopeCosts.Sum(s => _financeService.RoundAmount(s.Quantity * s.NetAmount)))
            }).ToList();

        var totalSales = offers.Sum(s => s.Total);
        var totalCosts = costs.Sum(s => s.Total);
        var rates = new decimal[] { assumption.CompanyCost, assumption.CompanyGuarantee, assumption.Insurance };
        var totalDiscountCosts = _financeService.ApplyDiscount(totalCosts, assumption.Discount) - _financeService.CalculatePercentageOfRates(totalCosts, rates);

        var vm = new AssumptionsVm
        {
            Assumption = assumption,
            WorkScopesSum = new WorkScopeSumDto
            {
                TotalSales = totalSales,
                TotalCosts = totalCosts,
                TotalDiscountCosts = totalDiscountCosts,
                Sales = new List<WorkScopeSettl>
                {
                    new()
                    {
                        ScopeType = WorkScopeType.Agregat,
                        ScopeAmount = _financeService.CalculateSumAmounts(offers.Where(x=>x.WorkScopeType == WorkScopeType.Agregat).Select(x=> x.Total)),
                    },
                    new()
                    {
                        ScopeType = WorkScopeType.Installation,
                        ScopeAmount = _financeService.CalculateSumAmounts(offers.Where(x=>x.WorkScopeType == WorkScopeType.Installation).Select(x=> x.Total)),
                    },
                    new()
                    {
                        ScopeType = WorkScopeType.Aadministration,
                        ScopeAmount = _financeService.CalculateSumAmounts(offers.Where(x=>x.WorkScopeType == WorkScopeType.Aadministration).Select(x=> x.Total)),
                    },
                },

                Costs = new List<WorkScopeSettl>
                {
                    new()
                    {
                        ScopeType = WorkScopeType.Agregat,
                        ScopeAmount = _financeService.CalculateSumAmounts(costs.Where(x=>x.WorkScopeType == WorkScopeType.Agregat).Select(x=> x.Total)),
                    },
                    new()
                    {
                        ScopeType = WorkScopeType.Installation,
                        ScopeAmount = _financeService.CalculateSumAmounts(costs.Where(x=>x.WorkScopeType == WorkScopeType.Installation).Select(x=> x.Total)),
                    },
                    new()
                    {
                        ScopeType = WorkScopeType.Aadministration,
                        ScopeAmount = _financeService.CalculateSumAmounts(costs.Where(x=>x.WorkScopeType == WorkScopeType.Aadministration).Select(x=> x.Total)),
                    },
                }
            }
        };
        return vm;
    }
}
