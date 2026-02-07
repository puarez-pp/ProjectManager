 using ProjectManager.Application.Projects.Commands.EditProject;
using ProjectManager.Application.Users.Queries.GetUser;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Queries.GetEditProject;

public class EditProjectVm
{
    public EditProjectCommand Project { get; set; }
    public List<Client> AvaiableClients = new();
    public List<UserDto> AvailableEmployee = new();
}
