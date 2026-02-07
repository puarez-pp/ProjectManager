using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Users.Extensions;

namespace ProjectManager.Application.Posts.Queries.GetCommnents;

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
            .FirstOrDefaultAsync(x => x.Id == request.Id);
            
        
        if (project == null)
            throw new Exception($"Coś poszło nie tak.");

        var vm = new GetCommentsVm
        {
            Project = new Projects.Queries.GetProject.ProjectDto(),
            Posts = project.Posts.OrderByDescending(x=>x.CreatedAt)
                    .Select(x => new PostDto
                    {
                        Id = x.Id,
                        Body = x.Body,
                        CreatedAt = x.CreatedAt,
                        User = x.User.ToUserDto().FullName,
                        Replies = x.PostReplies.OrderByDescending(pr => pr.CreatedAt)
                                        .Select(pr => pr.ToPostReplyDto())
                                        .ToList()
                    }).ToList()
        };
        return vm;
    }
}
