using MediatR;

namespace ProjectManager.Application.Todos.Queries.GetEditTodo;

public class GetEditTodoQuery:IRequest<EditTodoVm>
{
    public int Id { get; set; }
}
