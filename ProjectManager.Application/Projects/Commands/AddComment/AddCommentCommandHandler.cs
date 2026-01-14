using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Commands.AddComment;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUser;

    public AddCommentCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUser)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _currentUser = currentUser;
    }
    public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            ProjectId = request.ProjectId,
            Title = request.Title,
            Content = request.Content,
            CreatedDate = _dateTimeService.Now,
            UserId = _currentUser.UserId
        };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync(cancellationToken);
        return post.Id;

    }
}
