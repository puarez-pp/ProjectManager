using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Calculations;

namespace ProjectManager.Application.Settlements.Queries.GetCostSummary;

public class GetCostSummaryQueryHandler : IRequestHandler<GetCostSummaryQuery, CostSummaryVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ISettlementService _calc;

    public GetCostSummaryQueryHandler(
        IApplicationDbContext context,
        ISettlementService calc)
    {
        _context = context;
        _calc = calc;
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
            .Select(x => new { x.MarginGen, x.MarginInstall })
            .FirstOrDefaultAsync(cancellationToken);

        var offerSums = await _context.WorkScopeOffers
            .AsNoTracking()
            .Where(o => o.WorkScope.Settlement.ProjectId == request.Id)
            .GroupBy(o => new
            {
                o.WorkScopeId,
                o.WorkScope.WorkScopeType,
                o.WorkScope.Description,
                o.WorkScope.Order
            })
            .Select(g => new WorkScopeOfferCostBase
            {
                WorkScopeId = g.Key.WorkScopeId,
                WorkScopeType = g.Key.WorkScopeType,
                Description = g.Key.Description,
                Order = g.Key.Order,
                SumNet = g.Sum(x => x.Quantity * x.NetAmount)
            })
            .ToListAsync(cancellationToken);

        var costSums = await _context.WorkScopeCosts
            .AsNoTracking()
            .Where(c => c.WorkScope.Settlement.ProjectId == request.Id)
            .GroupBy(c => new
            {
                c.WorkScopeId,
                c.WorkScope.WorkScopeType,
                c.WorkScope.Description,
                c.WorkScope.Order
            })
            .Select(g => new WorkScopeOfferCostBase
            {
                WorkScopeId = g.Key.WorkScopeId,
                WorkScopeType = g.Key.WorkScopeType,
                Description = g.Key.Description,
                Order = g.Key.Order,
                SumNet = g.Sum(x => x.Quantity * x.NetAmount)
            })
            .ToListAsync(cancellationToken);

        var scopeCosts = _calc.CalculateCostSummary(
            offerSums,
            costSums,
            margins.MarginGen,
            margins.MarginInstall);

        return new CostSummaryVm
        {
            Project = project,
            Offers = scopeCosts.Sum(x => x.Offer),
            Costs = scopeCosts.Sum(x => x.Cost),
            Profits = scopeCosts.Sum(x => x.Profit),
            ScopeCosts = scopeCosts.ToList()
        };
    }
}
