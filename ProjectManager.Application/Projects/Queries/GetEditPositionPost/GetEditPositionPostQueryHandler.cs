using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Commands.EditPositionPost;
using ProjectManager.Application.Projects.Extensions;

namespace ProjectManager.Application.Projects.Queries.GetEditPositionPost;

public class GetEditPositionPostQueryHandler : IRequestHandler<GetEditPositionPostQuery, EditPostCommand>
{
    private readonly IApplicationDbContext _context;

    public GetEditPositionPostQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditPostCommand> Handle(GetEditPositionPostQuery request, CancellationToken cancellationToken)
    {
        var post = await _context
            .PositionPosts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        return new EditPostCommand
        {
            Id = post.Id,
            PositionId = post.PositionId,
            Content = post.Content
        };  

    }
}
