using MediatR;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class GetProjectTodosQuery:IRequest<ProjectTodos>
{
    public int Id { get; set; }
}
