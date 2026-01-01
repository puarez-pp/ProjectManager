using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Employees.Commands.EditEmployee;
public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserRoleManagerService _userRoleManagerService;
    private readonly IRoleManagerService _roleManagerService;

    public EditEmployeeCommandHandler(
        IApplicationDbContext context,
        IUserRoleManagerService userRoleManagerService,
        IRoleManagerService roleManagerService)
    {
        _context = context;
        _userRoleManagerService = userRoleManagerService;
        _roleManagerService = roleManagerService;
    }
    public async Task<Unit> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;

        if (user.Employee == null)
            user.Employee = new Domain.Entities.Employee();

        user.Employee.UserId = request.Id;
        user.Employee.ImageUrl = request.ImageUrl;
        user.Employee.Position = (Position)request.PositionId;
        user.Employee.ManagerId = request.ManagerId;


        await _context.SaveChangesAsync(cancellationToken);

        if (request.RoleIds != null && request.RoleIds.Any())
            await UpdateRoles(request.RoleIds, request.Id);

        return Unit.Value;
    }

    private async Task UpdateRoles(List<string> newRoleIds, string userId)
    {
        var roles = _roleManagerService.GetRoles().Select(x => new IdentityRole { Id = x.Id, Name = x.Name });

        var oldRoles = await GetOldRoles(userId);
        var newRoles = GetNewRoles(newRoleIds, roles);

        await RemoveRoles(userId, oldRoles, newRoles);

        await AddNewRoles(userId, oldRoles, newRoles);
    }

    private async Task AddNewRoles(string userId, List<IdentityRole> oldRoles, List<IdentityRole> newRoles)
    {
        var roleToAdd = newRoles.Except(oldRoles, x => x.Id);

        foreach (var role in roleToAdd)
            await _userRoleManagerService.AddToRoleAsync(userId, role.Name);
    }

    private async Task RemoveRoles(string userId, List<IdentityRole> oldRoles, List<IdentityRole> newRoles)
    {
        var roleToRemove = oldRoles.Except(newRoles, x => x.Id);

        foreach (var role in roleToRemove)
            await _userRoleManagerService.RemoveFromRoleAsync(userId, role.Name);
    }

    private List<IdentityRole> GetNewRoles(List<string> newRoleIds, IEnumerable<IdentityRole> roles)
    {
        var newRoles = new List<IdentityRole>();

        foreach (var roleId in newRoleIds)
            newRoles.Add(new IdentityRole { Id = roleId, Name = roles.FirstOrDefault(x => x.Id == roleId).Name });

        return newRoles;
    }

    private async Task<List<IdentityRole>> GetOldRoles(string userId)
    {
        return (await _userRoleManagerService.GetRolesAsync(userId)).ToList();
    }
}
