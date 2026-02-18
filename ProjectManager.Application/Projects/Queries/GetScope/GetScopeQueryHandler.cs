using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Projects.Queries.GetScopes;

public class GetScopeQueryHandler : IRequestHandler<GetScopeQuery, ProjectScopeDto>
{
    private readonly IApplicationDbContext _context;

    public GetScopeQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ProjectScopeDto> Handle(GetScopeQuery request, CancellationToken cancellationToken)
    {
        var scope = await _context
           .ProjectScopes
           .AsNoTracking()
           .Where(x => x.Id == request.Id)
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
           .SingleOrDefaultAsync();
        return scope;
    }
}
