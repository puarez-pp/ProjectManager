using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Todos.Extensions;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetUserTodos;

public class GetUserTodosQueryHandler : IRequestHandler<GetUserTodosQuery, IEnumerable<TodoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;

    public GetUserTodosQueryHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser)
    {
        _context = context;
        _currentUser = currentUser;
    }
    public async Task<IEnumerable<TodoDto>> Handle(GetUserTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _context
            .Todos
            .Include(x=>x.UserFrom)
            .ThenInclude(x=>x.Employee)
            .Include(x => x.UserTo)
            .ThenInclude(x => x.Employee)
            .AsNoTracking()
            .Where(x => x.UserToId == _currentUser.UserId)
            .OrderByDescending(x=>x.CreatedAt)
            .Select(x=>x.ToTodoDto())
            .ToListAsync();

        return todos;
    }
}
