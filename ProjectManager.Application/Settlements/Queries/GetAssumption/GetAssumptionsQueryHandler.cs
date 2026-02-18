using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;
using ProjectManager.Application.Users.Queries.GetUser;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetAssumption;

public class GetAssumptionsQueryHandler : IRequestHandler<GetAssumptionQuery, AssumptionsVm>
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
    public async Task<AssumptionsVm> Handle(GetAssumptionQuery request, CancellationToken cancellationToken)
    {
        var project = (await _context
            .Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id))
            .ToBasicsProjectDto();


        var settlement = await _context
            .Settlements
            .AsNoTracking()
            .Where(x => x.ProjectId == request.Id)
            .Select(p => new SettlementDto
            {
                Id = p.Id,
                Assumption = new AssumptionDto
                {
                    Id = p.Assumption.Id,
                    Discount = p.Assumption.Discount,
                    Insurance = p.Assumption.Insurance,
                    MarginGen = p.Assumption.MarginGen,
                    MarginInstall = p.Assumption.MarginInstall,
                    Maturity = p.Assumption.Maturity,
                    CompanyCost = p.Assumption.CompanyCost,
                    CompanyGuarantee = p.Assumption.CompanyGuarantee,
                },
                User = new UserDto
                {
                    FullName = $"{p.User.FirstName} {p.User.LastName}",
                    Employee = new EmployeeDto()
                },
                CreatedAt = p.CreatedAt,
                WorkScopes = p.WorkScopes
                .OrderBy(s => s.Order)
                .Select(s => new WorkScopeDto
                {
                    Id = s.Id,
                    Description = s.Description,
                    WorkScopeType = s.WorkScopeType,
                    Offers = s.WorkScopeOffers
                    .OrderBy(o => o.Order)
                    .Select(o => new WorkScopeOfferDto
                    {
                        Id = o.Id,
                        Quantity = o.Quantity,
                        NetAmount = o.NetAmount,
                    })
                    .ToList(),
                    Costs = s.WorkScopeCosts
                    .OrderBy(c => c.Order)
                    .Select(c => new WorkScopeCostDto
                    {
                        Id = c.Id,
                        Quantity = c.Quantity,
                        NetAmount = c.NetAmount,
                    })
                    .ToList()
                })
                .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (settlement == null)
        {
            return new AssumptionsVm
            {
                Project = project,
                Assumption = new AssumptionDto
                {
                    Id = 0,
                },
            };

        };
        
        var settlements = settlement.WorkScopes;
        var assumption = settlement.Assumption;

        var offers = settlements
            .GroupBy(g => g.WorkScopeType)
            .Select(x => new
            {
                WorkScopeType = x.Key,
                Total = x.Sum(g=>g.Offers.Sum(s=>_financeService.ApplyMargin(s.Quantity * s.NetAmount, x.Key == WorkScopeType.Agregat ? assumption.MarginGen : assumption.MarginInstall))),
            }).ToList();

        var costs = settlements
            .GroupBy(g => g.WorkScopeType)
            .Select(x => new
            {
                WorkScopeType = x.Key,
                Total = x.Sum(y => y.Costs.Sum(s => _financeService.RoundAmount(s.Quantity * s.NetAmount)))
            }).ToList();

        var rates = new decimal[] { assumption.CompanyCost, assumption.CompanyGuarantee, assumption.Insurance };
        var totalSales = offers.Sum(s => s.Total);
        var totalImplementation = costs.Sum(s => s.Total);
        var totalOverheads = _financeService.CalculatePercentageOfRates(totalImplementation,rates);
        var totalAfterDiscount = _financeService.ApplyDiscount(totalImplementation, assumption.Discount) + totalOverheads;

        var vm = new AssumptionsVm
        {
            Project = project,
            Assumption = settlement.Assumption,
            WorkScopesSum = new WorkScopeSumDto
            {
                TotalSales = totalSales,
                TotalImplementation = totalImplementation,
                TotalOverheads = totalOverheads,
                TotalCosts = totalImplementation + totalOverheads,
                TotalAfterDiscount = totalAfterDiscount,
                Margin = _financeService.CalculateMarginRate(totalImplementation + totalOverheads, totalSales),
                FinalMargin = _financeService.CalculateMarginRate(totalAfterDiscount, totalSales),
                FinalProfit = _financeService.CalculateDifferenceAmounts(totalSales, totalAfterDiscount),
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
