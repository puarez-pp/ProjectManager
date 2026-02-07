using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Commands.EditProject;
using ProjectManager.Application.Users.Extensions;

namespace ProjectManager.Application.Projects.Queries.GetEditProject;

public class GetEditProjectQueryHandler : IRequestHandler<GetEditProjectQuery, EditProjectVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditProjectQueryHandler(IApplicationDbContext context)
    {
        _context = context;
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

        vm.AvailableEmployee = await _context
            .Users
            .AsNoTracking ()
            .Include(x=>x.Employee)
            .Select(x=>x.ToUserDto())
            .ToListAsync();

        vm.AvaiableClients = await _context
            .Clients
            .AsNoTracking()
            .ToListAsync();
        return vm;
    }
}
