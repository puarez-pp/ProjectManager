using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Posts.Commands.DeletePost;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _context
            .PositionPosts
            .FirstOrDefaultAsync(x=>x.Id == request.Id);
        if (post != null)
        {
            _context.PositionPosts.Remove(post);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
