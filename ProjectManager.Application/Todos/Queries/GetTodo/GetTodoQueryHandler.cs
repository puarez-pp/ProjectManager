using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Todos.Extensions;

namespace ProjectManager.Application.Todos.Queries.GetTodo;

public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoVm>
{
    private readonly IApplicationDbContext _context;

    public GetTodoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<TodoVm> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .Include(x=>x.Client)
            .Include(x=>x.User)
            .FirstOrDefaultAsync(x => x.Todos.Any(x => x.Id == request.Id));


        var todo = await _context
            .Todos
            .Include(x => x.UserFrom)
            .ThenInclude(x => x.Employee)
            .Include(x => x.UserTo)
            .ThenInclude(x => x.Employee)
            .Include(x => x.TodoPosts)
            .ThenInclude(x => x.User)
            .ThenInclude(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == request.Id);


        var vm = new TodoVm
        {
            Project = new ProjectDto(),
            Todo = todo.ToTodoDto(),
            Replies = todo.TodoPosts.Select(x => x.ToTodoReplyDto()).OrderByDescending(x => x.CreatedAt).ToList(),
        };

        return vm;
    }
}
