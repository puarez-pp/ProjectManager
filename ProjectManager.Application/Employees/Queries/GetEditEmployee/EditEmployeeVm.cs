using ProjectManager.Application.Employees.Commands.EditEmployee;
using ProjectManager.Application.Roles.Queries.GetRoles;
using ProjectManager.Application.Users.Queries.GetUser;

namespace GymManager.Application.Employees.Queries.GetEditEmployee;
public class EditEmployeeVm
{
    public EditEmployeeCommand Employee { get; set; }
    public List<RoleDto> AvailableRoles { get; set; }
    public List<UserDto> AvailableManagers = new();
    public string EmployeeFullPathImage { get; set; }
}
