using ProjectManager.Application.Projects.Commands.EditDivision;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Projects.Queries.GetEditDivision;

public class EditDivisionVm
{
    public ProjectBasicsDto Project { get; set; }
    public EditDivisionCommand Division { get; set; }
    public List<UserDto> AvailableEmployees = new();
}
