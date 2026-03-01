using MediatR;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class GetProjectTodosQuery:IRequest<ProjectTodosVm>
{
    public int Id { get; set; }
    public int PageIndex { get; set; } = 1;
}
