using MediatR;
using ProjectManager.Application.Common.Models;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetUserTodos;

public class GetUserTodosQuery:IRequest<PaginatedList<TodoDto>>
{
    public int PageIndex { get; set; } = 1;
    public string UserId { get; set; }
}

