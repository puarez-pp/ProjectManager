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
            .Select(x => new ProjectBasicsDto
            {
                Id = x.Id,
                ProjectType = x.ProjectType,
                ProjectStatus = x.Status,
                Number = x.Number,
                Name = x.Name,
                ClientId = x.ClientId,
                Client = x.Client.Name,
                Sharepoint = x.Sharepoint,
                EditAt = x.EditAt
            })
            .ToListAsync();
        return projects;
    }
}
