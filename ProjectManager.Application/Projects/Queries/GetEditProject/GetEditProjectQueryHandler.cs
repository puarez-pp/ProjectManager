using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Projects.Commands.EditProject;
using ProjectManager.Application.Users.Extensions;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Projects.Queries.GetEditProject;

public class GetEditProjectQueryHandler : IRequestHandler<GetEditProjectQuery, EditProjectVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserRoleManagerService _userRoleManager;

    public GetEditProjectQueryHandler(
        IApplicationDbContext context,
        IUserRoleManagerService userRoleManager)
    {
        _context = context;
        _userRoleManager = userRoleManager;
    }
    public async Task<EditProjectVm> Handle(GetEditProjectQuery request, CancellationToken cancellationToken)
    {
        var vm = new EditProjectVm();

        var project = await _context
            .Projects
            .AsNoTracking()
            .Include(x => x.UserPM)
            .Include(x => x.DesignEng)
            .Include(x => x.ElectricEng)
            .Include(x => x.Client)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        vm.Project = new EditProjectCommand
        {
            Id = project.Id,
            ProjectType = project.ProjectType,
            ProjectStatus = project.Status,
            Comment = project.Comment,
            Number = project.Number,
            Name = project.Name,
            ClientId = project.ClientId,
            UserPMId = project.UserPMId,
            DesignEngId = project.DesignEngId,
            ElectricEngId = project.ElectricEngId,
            Sharepoint = project.Sharepoint
        };

        vm.AvailableEmployees = await 
            _context
            .Users
            .AsNoTracking ()
            .Select(x=>new UserDto
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                FullName = $"{x.FirstName} {x.LastName}",
                Employee = new EmployeeDto(),
            }).ToListAsync();


        vm.AvaiableClients = await _context
            .Clients
            .AsNoTracking()
            .ToListAsync();
        return vm;
    }
}
