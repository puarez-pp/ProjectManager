using MediatR;

namespace ProjectManager.Application.Todos.Commands.DeleteTodoPost;

public class DeleteTodoPostCommand:IRequest
{
    public int Id { get; set; }
}
