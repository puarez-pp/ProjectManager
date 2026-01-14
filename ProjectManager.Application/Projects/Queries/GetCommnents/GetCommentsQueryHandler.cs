using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;

namespace ProjectManager.Application.Projects.Queries.GetCommnents;

public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, GetCommentsVm>
{
    private readonly IApplicationDbContext _context;

    public GetCommentsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetCommentsVm> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Include(x => x.Posts)
            .ThenInclude(x => x.User)
            .ThenInclude(x => x.PostReplies)
            .ThenInclude(x => x.User)
            .Include(x => x.Divisions)
            .ThenInclude(x => x.Positions)
            .ThenInclude(x => x.PositionPosts)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        
        if (project == null)   
            return null;
        var vm = new GetCommentsVm
        {
            Project = project.ToProjectDto(),
            Posts = project.Posts
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => x.ToPostDto())
                .ToList(),
            PostReplies = project.Posts.SelectMany(x => x.PostReplies.Select(x => x.ToPostReplyDto()))
                .GroupBy(x => x.PostId)
                .Select(g => g.OrderByDescending(x => x.CreatedDate).ToList())
                .ToList(),
            PositionPosts = project.Divisions.SelectMany(x => x.Positions)
                .SelectMany(x => x.PositionPosts)
                .Select(x => x.ToPositionPostDto())
                .GroupBy(x => x.PositionId)
                .Select(g => g.OrderByDescending(x => x.CreatedDate).ToList())
                .ToList()
        };
        return vm;
    }
}
