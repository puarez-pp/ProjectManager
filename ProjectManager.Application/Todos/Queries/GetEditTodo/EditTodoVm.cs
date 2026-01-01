using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Todos.Commands.EditTodo;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetEditTodo;

public class EditTodoVm
{
    public int Id { get; set; }
    public ProjectDto Project { get; set; }
    public EditTodoCommand Todo { get; set; }
    public List<UserDto> AvaiableUsers = new();
}
 