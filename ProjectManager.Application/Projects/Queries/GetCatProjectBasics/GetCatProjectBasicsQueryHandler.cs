using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;

namespace ProjectManager.Application.Projects.Queries.GetCatProjectBasics;

public class GetCatProjectBasicsQueryHandler : IRequestHandler<GetCatProjectBasicsQuery, IEnumerable<ProjectBasicsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetCatProjectBasicsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ProjectBasicsDto>> Handle(GetCatProjectBasicsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _context
            .Projects
            .AsNoTracking()
            .Where(x => x.ProjectType == request.ProjectTypeId)
            .Select(x => x.ToBasicsProjectDto())
            .ToListAsync();
        return projects;
    }
}
