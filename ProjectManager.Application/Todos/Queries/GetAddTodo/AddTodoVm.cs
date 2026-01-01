using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Todos.Commands.AddTodo;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetAddTodo;

public class AddTodoVm
{
    public ProjectDto Project { get; set; }
    public AddTodoCommand Todo { get; set; }
    public List<UserDto> AvaiableUsers = new();
}
