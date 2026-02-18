using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Commands.AddWorkScopeCost;
using ProjectManager.Application.SubContractors.Extension;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetAddWorkScopeCost;

public class GetAddWorkScopeCostQueryHandler : IRequestHandler<GetAddWorkScopeCostQuery, AddWorkScopeCostVm>
{
    private readonly IApplicationDbContext _context;

    public GetAddWorkScopeCostQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<AddWorkScopeCostVm> Handle(GetAddWorkScopeCostQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(p => p.Settlement.WorkScopes.Any(s => s.Id == request.Id))
            .Select(p => new ProjectBasicsDto
            {
                Id = p.Id,
                Name = p.Name,
            })
            .FirstOrDefaultAsync(cancellationToken);

        var subContractors = await _context
            .SubContractors
            .Select(x => x.ToSubContractorBasicsDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var vm = new AddWorkScopeCostVm
        {
            Project = project,
            SubContractors = subContractors,
            ScopeCost = new AddWorkScopeCostCommand 
            { 
                WorkScopeId = request.Id, 
                CostStatusType = CostStatusType.Invoice,
                Quantity = 1,
                NetAmount = 1,
            }
        };
        return vm;
    }
}
