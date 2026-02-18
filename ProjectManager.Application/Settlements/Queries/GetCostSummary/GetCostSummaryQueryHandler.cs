using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;
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

        var margins = await _context
            .Assumptions
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id)
            .Select(x => new {marginGen = x.MarginGen, marginInst = x.MarginInstall })
            .FirstOrDefaultAsync();

        var settlement = await _context
            .WorkScopes
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id)
            .Select(s => new
            {
                s.Id,
                s.Description,
                s.Order,
                s.WorkScopeType,
                Offers = s.WorkScopeOffers.Select(y => new
                {
                    y.Id,
                    y.Description,
                    y.Order,
                    y.IsUsed,
                    y.UnitType,
                    y.Quantity,
                    y.NetAmount,
                    SubContractor = y.SubContractor.Name
                }).OrderBy(c => c.Order).ToList(),
                Costs = s.WorkScopeCosts.Select(z => new
                {
                    z.Id,
                    z.Description,
                    z.Order,
                    z.UnitType,
                    z.Quantity,
                    z.NetAmount,
                    SubContractor = z.SubContractor.Name
                }).OrderBy(c => c.Order).ToList()
            })
            .OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);

        var workScopes = settlement
            .GroupBy(g => g.Id)
            .Select(s => new ScopeCostSummaryDto
            {
                Id = s.Key,
                Description = s.First().Description,
                Offer = s.Sum(g => g.Offers.Sum(o => _financeService.ApplyMargin(o.Quantity * o.NetAmount, s.First().WorkScopeType == WorkScopeType.Agregat ? margins.marginGen : margins.marginInst))),
                Cost = s.Sum(g => g.Costs.Sum(c => _financeService.RoundAmount(c.Quantity * c.NetAmount))),
                Profit = s.Sum(g => g.Offers.Sum(o => _financeService.ApplyMargin(o.Quantity * o.NetAmount, s.First().WorkScopeType == WorkScopeType.Agregat ? margins.marginGen : margins.marginInst))) - s.Sum(g => g.Costs.Sum(c => _financeService.RoundAmount(c.Quantity * c.NetAmount)))
            }).ToList();

        var vm = new CostSummaryVm
        {
            Project = project,
            Offers = _financeService.CalculateSumAmounts(workScopes.Select(x => x.Offer)),
            Costs = _financeService.CalculateSumAmounts(workScopes.Select(x => x.Cost)),
            Profits = _financeService.CalculateSumAmounts(workScopes.Select(x => x.Profit)),
            ScopeCosts = workScopes
        };
        return vm;
     
    }
}
