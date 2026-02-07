using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Posts.Queries.GetPositionPosts;

public class GetPositionPostsQueryHandler : IRequestHandler<GetPositionPostsQuery, List<PositionPostDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPositionPostsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<PositionPostDto>> Handle(GetPositionPostsQuery request, CancellationToken cancellationToken)
    {
        var posts =  await _context
            .PositionPosts
            .Where(x=>x.PositionId == request.Id)
            .OrderByDescending(x=>x.CreatedAt)
            .Select(p=> new PositionPostDto
            {
                Id = p.Id,
                PositionId = request.Id,
                Body = p.Body,
                CreatedAt = p.CreatedAt,
                User = new UserDto
                {
                    FullName = $"{p.User.FirstName} {p.User.LastName}",
                    Employee = new EmployeeDto { }
                }
            }).ToListAsync(cancellationToken);
        return posts;
    }
}
