using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Posts.Commands.EditPositionPost;

public class EditPostCommandHandler : IRequestHandler<EditPostCommand>
{
    private readonly IApplicationDbContext _context;

    public EditPostCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        var post = await _context
            .PositionPosts
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        post.Content = request.Content;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
