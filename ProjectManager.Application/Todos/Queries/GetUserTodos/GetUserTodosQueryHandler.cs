using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Common.Models;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetUserTodos;

public class GetUserTodosQueryHandler : IRequestHandler<GetUserTodosQuery, PaginatedList<TodoDto>>
{
    private readonly IApplicationDbContext _context;

    public GetUserTodosQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedList<TodoDto>> Handle(GetUserTodosQuery request, CancellationToken cancellationToken)
    {
        const int pageSize = 5;
        var todos = await _context
            .Todos
            .AsNoTracking()
            .Where(x => x.UserToId == request.UserId)
            .Select(x => new TodoDto
            {
                Id = x.Id,
                Title = x.Title,
                Body = x.Body,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt,
                FinishDate = x.FinishDate,
                CompletionDate = x.CompletionDate,
                UserFrom = new UserDto
                {
                    Id = x.UserFrom.Id,
                    FullName = $"{x.UserFrom.FirstName} {x.UserFrom.LastName}",
                    Employee = new EmployeeDto()
                },
                UserTo = new UserDto
                {
                    Id = x.UserTo.Id,
                    FullName = $"{x.UserTo.FirstName} {x.UserTo.LastName}",
                    Employee = new EmployeeDto()
                },
                PostsNumber = x.TodoPosts.Count()
            })
            .OrderByDescending(x => x.CreatedAt)
            .PaginatedListAsync(request.PageIndex, pageSize);
        return todos;
    }
}
