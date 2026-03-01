using ProjectManager.Application.Common.Models;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class ProjectTodosVm
{
    public ProjectBasicsDto Project { get; set; }
    public PaginatedList<TodoDto> Todos { get; set; }
}
