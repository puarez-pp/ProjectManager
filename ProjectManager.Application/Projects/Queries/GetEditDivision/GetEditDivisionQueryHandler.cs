using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Commands.EditDivision;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Users.Extensions;

namespace ProjectManager.Application.Projects.Queries.GetEditDivision;

public class GetEditDivisionQueryHandler : IRequestHandler<GetEditDivisionQuery, EditDivisionVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditDivisionQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditDivisionVm> Handle(GetEditDivisionQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Include(x => x.Client)
            .Include(x => x.User)
            .ThenInclude(x => x.Employee)
            .Include(x => x.Divisions)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Divisions.Any(y => y.Id == request.Id));

        var vm = new EditDivisionVm();
        var division = project.Divisions.FirstOrDefault(x => x.Id == request.Id);
        vm.Division = new EditDivisionCommand
        {
            Id = request.Id,
            UserId = division.UserId,
            DivisionType = division.DivisionType.GetDisplayName()
        };

        vm.Project = project.ToBasicsProjectDto();
        vm.AvailableEmployees = await _context
            .Users
            .Include(x => x.Employee)
            .Select(x => x.ToUserDto())
            .ToListAsync();
        return vm;
    }
}
