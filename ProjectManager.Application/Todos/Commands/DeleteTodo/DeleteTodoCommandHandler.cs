using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _context
            .Todos
            .Include(x=>x.TodoPosts)
            .FirstOrDefaultAsync(x=>x.Id == request.Id);
        if (todo != null)
        {
            foreach (var reply in todo.TodoPosts)
            {
                _context.TodoPosts.Remove(reply);
            }
            await _context.SaveChangesAsync(cancellationToken);
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
