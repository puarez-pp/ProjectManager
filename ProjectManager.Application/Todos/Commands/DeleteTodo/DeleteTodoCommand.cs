using MediatR;

namespace ProjectManager.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommand:IRequest
{
    public int Id { get; set; }
}
