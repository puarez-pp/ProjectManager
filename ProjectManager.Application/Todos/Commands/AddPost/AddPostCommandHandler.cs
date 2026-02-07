using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Todos.Commands.AddPost;

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
        var post = new TodoPost();
        post.TodoId = request.TodoId;
        post.Content = request.Content;
        post.UserId = _currentUser.UserId;
        post.CreatedAt = _dateTime.Now;
        await _context.TodoPosts.AddAsync(post);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
