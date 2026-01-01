using MediatR;

namespace ProjectManager.Application.Todos.Queries.GetAddTodo;

public class GetAddTodoQuery:IRequest<AddTodoVm>
{
    public int Id { get; set; }
}
