using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Todos.Extensions;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetFromUserTodos
{
    public class GetFromUserTodosQueryHandler : IRequestHandler<GetFromUserTodosQuery, IEnumerable<TodoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public GetFromUserTodosQueryHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService)
        {
            _context = applicationDbContext;
            _currentUser = currentUserService;
        }
        public async Task<IEnumerable<TodoDto>> Handle(GetFromUserTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _context
            .Todos
            .Include(x => x.UserFrom)
            .ThenInclude(x => x.Employee)
            .Include(x => x.UserTo)
            .ThenInclude(x => x.Employee)
            .AsNoTracking()
            .Where(x => x.UserFromId == _currentUser.UserId)
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => x.ToTodoDto())
            .ToListAsync();

            return todos;
        }
    }
}
