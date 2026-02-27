using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetTodo;

public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoDto>
{
    private readonly IApplicationDbContext _context;

    public GetTodoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todo = await _context
            .Todos
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
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
                    FullName = $"{x.UserFrom.FirstName} {x.UserFrom.LastName}",
                    Employee = new EmployeeDto()
                },
                UserTo = new UserDto
                {
                    FullName = $"{x.UserTo.FirstName} {x.UserTo.LastName}",
                    Employee = new EmployeeDto()
                },
                PostsNumber = x.TodoPosts.Count()
            })
            .FirstOrDefaultAsync(cancellationToken);
        return todo;
    }
}
