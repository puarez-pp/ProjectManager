
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetTodo;

public class TodoVm
{
    public ProjectDto Project { get; set; }
    public TodoDto Todo { get; set; }
    public List<TodoReplyDto> Replies { get; set; }
}
