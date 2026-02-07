using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Projects.Queries.GetScopes;

public class GetScopesQueryHandler : IRequestHandler<GetScopesQuery, List<ProjectScopeDto>>
{
    private readonly IApplicationDbContext _context;

    public GetScopesQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<ProjectScopeDto>> Handle(GetScopesQuery request, CancellationToken cancellationToken)
    {
        var scopes = await _context
           .ProjectScopes
           .AsNoTracking()
           .Where(x => x.ProjectId == request.Id)
           .OrderBy(s => s.Order)
           .Select(s => new ProjectScopeDto
           {
               Id = s.Id,
               Description = s.Description,
               Positions = s.Positions
                   .OrderBy(p => p.Order)
                   .Select(p => new ProjectScopePositionDto
                   {
                       Id = p.Id,
                       Description = p.Description,
                       IsCompleted = p.IsCompleted,
                       NotApplicable = p.NotApplicable,
                       CompletionDate = p.CompletionDate,
                   })
                   .ToList()
           })
           .ToListAsync();
        return scopes;

    }
}
