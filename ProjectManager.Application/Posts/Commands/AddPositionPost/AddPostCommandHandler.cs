using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Posts.Commands.AddPositionPost;

public class AddPostCommandHandler : IRequestHandler<AddPostCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;

    public AddPostCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var post = new PositionPost();
        post.Body = request.Body;
        post.PositionId = request.PositionId;
        post.CreatedAt = _dateTime.Now;
        post.UserId = _currentUser.UserId;
        await _context.PositionPosts.AddAsync(post);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
