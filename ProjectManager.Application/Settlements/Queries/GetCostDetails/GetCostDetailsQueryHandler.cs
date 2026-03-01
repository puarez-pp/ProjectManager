using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Calculations;

namespace ProjectManager.Application.Settlements.Queries.GetCostDetails;

public class GetCostDetailsQueryHandler : IRequestHandler<GetCostDetailsQuery, CostDetailsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ISettlementService _calc;

    public GetCostDetailsQueryHandler(
        IApplicationDbContext context,
        ISettlementService calc)
    {
        _context = context;
        _calc = calc;
    }

    public async Task<CostDetailsVm> Handle(GetCostDetailsQuery request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(s => new ProjectBasicsDto
            {
                Id = s.Id,
                Name = s.Name,
                Number = s.Number
            })
            .FirstOrDefaultAsync(cancellationToken);

        var rawScopes = await _context.WorkScopes
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id)
            .Select(s => new RawWorkScopeCost
            {
                Id = s.Id,
                Description = s.Description,
                Order = s.Order,
                Costs = s.WorkScopeCosts.Select(y => new RawCostItem
                {
                    Id = y.Id,
                    Description = y.Description,
                    CostStatusType = y.CostStatusType,
                    Order = y.Order,
                    UnitType = y.UnitType,
                    Quantity = y.Quantity,
                    NetAmount = y.NetAmount,
                    SubContractor = y.SubContractor.Name
                }).ToList()
            })
            .OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);

        var workScopes = _calc.CalculateCostDetails(rawScopes);

        return new CostDetailsVm
        {
            Project = project,
            Total = workScopes.Sum(s => s.Total),
            WorkScopes = workScopes.ToList()
        };
    }
}
