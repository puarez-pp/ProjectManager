using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Commands.EditWorkScopeCost;
using ProjectManager.Application.SubContractors.Extension;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeCost;

public class GetEditWorkScopeCostQueryHandler : IRequestHandler<GetEditWorkScopeCostQuery, EditWorkScopeCostVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditWorkScopeCostQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditWorkScopeCostVm> Handle(GetEditWorkScopeCostQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(p => p.Settlement.WorkScopes.Any(ws => ws.WorkScopeCosts.Any(wsc => wsc.Id == request.Id)))
            .Select(p => new ProjectBasicsDto
            {
                Id = p.Id,
                Name = p.Name,
            })
            .FirstOrDefaultAsync(cancellationToken);

        var subContractors = await _context
           .SubContractors
           .AsNoTracking ()
           .Select(x => x.ToSubContractorBasicsDto())
           .AsNoTracking()
           .ToListAsync(cancellationToken);

        var cost = await _context
            .WorkScopeCosts
            .FirstOrDefaultAsync(c => c.Id == request.Id);


        var vm = new EditWorkScopeCostVm
        {
            Project = project,
            SubContractors = subContractors,
            ScopeCost = new EditWorkScopeCostCommand
            {
                Id = request.Id,
                Description = cost.Description,
                CostStatusType = cost.CostStatusType,
                Quantity = cost.Quantity,
                UnitType = cost.UnitType,
                NetAmount = cost.NetAmount,
                EuroNetAmount = cost.EuroNetAmount,
                EuroRate = cost.EuroRate,
                SubContractorId = cost.SubContractorId
            }
        };
        return vm;
    }
}
