using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;

namespace ProjectManager.Application.Settlements.Queries.GetCostDetails;

public class GetCostDetailsQueryHandler : IRequestHandler<GetCostDetailsQuery, CostDetailsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IFinanceService _financeService;

    public GetCostDetailsQueryHandler(
        IApplicationDbContext context,
        IFinanceService financeService)
    {
        _context = context;
        _financeService = financeService;
    }
    public async Task<CostDetailsVm> Handle(GetCostDetailsQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(s => new ProjectBasicsDto
            {
                Id = s.Id,
                Name = s.Name,
                Number = s.Number
            })
            .FirstOrDefaultAsync(cancellationToken);

        var rawScopes = await _context
            .WorkScopes
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id)
            .Select(s => new
            {
                s.Id,
                s.Description,
                s.Order,
                Costs = s.WorkScopeCosts.Select(y => new
                {
                    y.Id,
                    y.Description,
                    y.Order,
                    y.UnitType,
                    y.Quantity,
                    y.NetAmount,
                    SubContractor = y.SubContractor.Name
                }).OrderBy(o => o.Order).ToList()
            })
            .OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);

        var workScopes = rawScopes.Select(s => new WorkScopeDto
        {
            Id = s.Id,
            Description = s.Description,
            Order = s.Order,

            Costs = s.Costs.Select(o => new WorkScopeCostDto
            {
                Id = o.Id,
                Description = o.Description,
                Order = o.Order,
                UnitType = o.UnitType,
                Quantity = o.Quantity,
                NetAmount = o.NetAmount,
                Total = _financeService.RoundAmount(o.Quantity * o.NetAmount),
                SubContractor = o.SubContractor
            }).ToList(),
            Total = s.Costs.Sum(o => _financeService.RoundAmount(o.Quantity * o.NetAmount))
        })
       .OrderBy(x => x.Order)
       .ToList();

        var vm = new CostDetailsVm
        {
            Project = project,
            Total = workScopes.Sum(s => s.Total),
            WorkScopes = workScopes
        };
        return vm;
    }
}
