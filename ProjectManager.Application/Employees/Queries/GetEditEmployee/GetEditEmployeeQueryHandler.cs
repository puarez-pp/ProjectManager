using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Users.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Enums;
using ProjectManager.Application.Users.Queries.GetUser;

namespace GymManager.Application.Employees.Queries.GetEditEmployee;
public class GetEditEmployeeQueryHandler : IRequestHandler<GetEditEmployeeQuery, EditEmployeeVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IRoleManagerService _roleManagerService;
    private readonly IUserRoleManagerService _userRoleManagerService;

    public GetEditEmployeeQueryHandler(
        IApplicationDbContext context,
        IRoleManagerService roleManagerService,
        IUserRoleManagerService userRoleManagerService)
    {
        _context = context;
        _roleManagerService = roleManagerService;
        _userRoleManagerService = userRoleManagerService;
    }

    public async Task<EditEmployeeVm> Handle(GetEditEmployeeQuery request, CancellationToken cancellationToken)
    {
        var vm = new EditEmployeeVm();

        vm.Employee = (await _context.Users
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == request.UserId))
            .ToEmployee();

        vm.Employee.RoleIds = (await _userRoleManagerService
            .GetRolesAsync(request.UserId))
            .Select(x => x.Id).ToList();

        vm.AvailableRoles = _roleManagerService.GetRoles().ToList();

        var availableManagers = await _context
            .Users
            .Include(x => x.Employee)
            .Where(x => x.Employee.Position == Position.Director || x.Employee.Position == Position.Manager)
            .ToListAsync();

        foreach (var manager in availableManagers)
        {

            vm.AvailableManagers.Add(manager.ToUserDto());
        }

        if (!string.IsNullOrWhiteSpace(vm.Employee.ImageUrl))
            vm.EmployeeFullPathImage = $"/Content/Files/{vm.Employee.ImageUrl}";

        return vm;
    }
}
