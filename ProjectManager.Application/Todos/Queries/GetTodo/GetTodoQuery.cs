using MediatR;

namespace ProjectManager.Application.Todos.Queries.GetTodo;

public class GetTodoQuery:IRequest<TodoVm>
{
    public int Id { get; set; }
}
