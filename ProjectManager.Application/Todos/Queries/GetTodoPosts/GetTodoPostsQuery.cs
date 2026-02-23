using MediatR;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetTodoPosts;

public class GetTodoPostsQuery : IRequest<List<TodoPostDto>>
{
    public int Id { get; set; }
}
