using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class ProjectTodos
{
    public ProjectDto Project { get; set; }
    public IEnumerable<TodoDto> Todos { get; set; }
}
