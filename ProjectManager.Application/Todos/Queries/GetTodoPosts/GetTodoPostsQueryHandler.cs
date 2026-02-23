using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetTodoPosts;

public class GetTodoPostsQueryHandler : IRequestHandler<GetTodoPostsQuery, List<TodoPostDto>>
{
    private readonly IApplicationDbContext _context;

    public GetTodoPostsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<TodoPostDto>> Handle(GetTodoPostsQuery request, CancellationToken cancellationToken)
    {
        
        var posts = await _context
            .TodoPosts
            .Where(x => x.TodoId == request.Id)
            .OrderByDescending(p => p.CreatedAt)
            .Select(x=> new TodoPostDto
            {
                Id = x.Id,
                Body = x.Body,
                CreatedAt = x.CreatedAt,
                User = new UserDto
                {
                    FullName = $"{x.User.FirstName} {x.User.LastName}",
                    Employee = new EmployeeDto()
                }
            }).
            ToListAsync(cancellationToken);
        return posts;
    }
}
