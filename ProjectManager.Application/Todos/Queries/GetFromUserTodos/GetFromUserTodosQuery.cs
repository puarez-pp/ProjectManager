using MediatR;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetFromUserTodos
{
    public class GetFromUserTodosQuery:IRequest<IEnumerable<TodoDto>>
    {
    }
}
