using MediatR;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetTodo;

public class GetTodoQuery:IRequest<TodoDto>
{
    public int Id { get; set; }
}
