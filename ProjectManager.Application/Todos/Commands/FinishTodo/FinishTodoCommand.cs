using MediatR;

namespace ProjectManager.Application.Todos.Commands.FinishTodo
{
    public class FinishTodoCommand: IRequest
    {
        public int Id { get; set; }
    }
}
