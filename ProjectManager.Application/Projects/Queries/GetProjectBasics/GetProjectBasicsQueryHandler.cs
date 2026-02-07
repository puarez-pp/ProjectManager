using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Projects.Queries.GetProjectBasics;

public class GetProjectBasicsQueryHandler : IRequestHandler<GetProjectBasicsQuery, IEnumerable<ProjectBasicsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetProjectBasicsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ProjectBasicsDto>> Handle(GetProjectBasicsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _context
            .Projects
            .AsNoTracking()
            .OrderByDescending(x => x.EditAt)
            .Select(x => new ProjectBasicsDto
            {
                Id = x.Id,
                ProjectType = x.ProjectType.GetDisplayName(),
                ProjectStatus = x.Status,
                Number = x.Number,
                Name = x.Name,
                Sharepoint = x.Sharepoint,
                Client = x.Client.Name,
                EditAt = x.EditAt,
            })
            .Take(4)
            .ToListAsync();

        return projects;
    }
}
