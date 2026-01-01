using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
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

        vm.Project = (await _context
            .Projects
            .Include(x=>x.User)
            .Include(x=>x.Client)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id))
            .ToEditProject();

        vm.AvailableManagers = await _context
            .Users
            .Include(x=>x.Employee)
            .Select(x=>x.ToUserDto())
            .ToListAsync();

        vm.AvaiableClients = await _context
            .Clients
            .ToListAsync();
        return vm;
    }
}
