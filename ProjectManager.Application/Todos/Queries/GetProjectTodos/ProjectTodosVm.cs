using ProjectManager.Application.Projects.Queries.GetProjectBasics;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class ProjectTodosVm
{
    public ProjectBasicsDto Project { get; set; }
    public List<TodoDto> Todos { get; set; }
}
