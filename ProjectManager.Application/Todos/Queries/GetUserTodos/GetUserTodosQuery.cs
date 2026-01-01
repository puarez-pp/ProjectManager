using MediatR;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetUserTodos;

public class GetUserTodosQuery:IRequest<IEnumerable<TodoDto>>
{
}
