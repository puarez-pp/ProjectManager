using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Users.Extensions;

namespace ProjectManager.Application.Projects.Queries.GetProject;

public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, GetProjectVm>
{
    private readonly IApplicationDbContext _context;

    public GetProjectQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetProjectVm> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
           .Projects
           .Include(x => x.Client)
           .Include(x => x.User)
           .ThenInclude(x => x.Employee)
           .Include(x => x.UserPM)
           .ThenInclude(x => x.Employee)
           .Include(x => x.UserUpdator)
           .ThenInclude(x => x.Employee)
           .Include(x=>x.Divisions)
           .ThenInclude(x=>x.User)
           .ThenInclude(x=>x.Employee)
           .AsNoTracking()
           .FirstOrDefaultAsync(x => x.Id ==request.Id);

        var positions = await _context
            .Divisions
            .Include(x => x.Positions)
            .ThenInclude(x => x.SubContractor)
            .Where(x => x.ProjectId == request.Id)
            .ToListAsync();


        var vm = new GetProjectVm
        {
            Project = new ProjectDto
            {
                Id = project.Id,
                ProjectType = (project.ProjectType).GetDisplayName(),
                ProjectStatus = project.Status,
                Number = project.Number,
                Name = project.Name,
                Sharepoint = project.Sharepoint,
                Comment = project.Comment,
                User = (project.User.ToUserDto()).FullName,
                UserUpdate = (project.UserUpdator.ToUserDto()).FullName,
                UserPM = (project.UserPM.ToUserDto()).FullName,
                Client = project.Client.Name,
                IsCompleted = project.IsCompleted,
                CreatedDate = project.CreatedDate,
                EditDate = project.EditDate,
                FinishedDate = project.FinishedDate
            },
            Divisions = project.Divisions.ToList(),
            Positions = positions.SelectMany(x=>x.Positions.GroupBy(x => x.DivisionId).Select(x => x.ToList())).ToList()
    };
        return vm;      
    }  
}
