using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Posts.Commands.AddCommentReply;

public class AddCommentReplyCommandHandler : IRequestHandler<AddCommentReplyCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTimeService;

    public AddCommentReplyCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTimeService = dateTimeService;
    }
    public async Task<int> Handle(AddCommentReplyCommand request, CancellationToken cancellationToken)
    {
        var post = new PostReply
        {
            PostId = request.PostId,
            Content = request.Content,
            CreatedDate = _dateTimeService.Now,
            UserId = _currentUser.UserId
        };
        await _context.PostReplies.AddAsync(post);
        await _context.SaveChangesAsync(cancellationToken);
        return post.Id;
    }
}
