using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Todos.Commands.DeleteTodoPost;

public class DeleteTodoPostCommandHandler : IRequestHandler<DeleteTodoPostCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoPostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteTodoPostCommand request, CancellationToken cancellationToken)
    {
        var post = await _context.
            TodoPosts
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (post != null)
        {
            _context.TodoPosts.Remove(post);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
