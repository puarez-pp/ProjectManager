using MediatR;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class GetProjectTodosQuery:IRequest<ProjectTodosVm>
{
    public int Id { get; set; }
    public bool ShowAll { get; set; }
}
