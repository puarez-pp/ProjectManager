using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;

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
            .Include(x => x.Client)
            .Include(x=>x.User)
            .ThenInclude(x=>x.Employee)
            .OrderByDescending(x => x.EditDate)
            .Take(4)
            .AsNoTracking()
            .Select(x => x.ToBasicsProjectDto())
            .ToListAsync();

        return projects;
    }
}
