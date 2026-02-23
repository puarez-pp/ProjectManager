using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Todos.Commands.AddTodo;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetAddTodo;

public class AddTodoVm
{
    public ProjectBasicsDto Project { get; set; }
    public AddTodoCommand Todo { get; set; }
    public List<UserDto> AvaiableUsers = new();
}
