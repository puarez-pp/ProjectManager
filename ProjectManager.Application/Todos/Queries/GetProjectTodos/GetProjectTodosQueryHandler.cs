using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Todos.Extensions;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class GetProjectTodosQueryHandler : IRequestHandler<GetProjectTodosQuery, ProjectTodos>
{
    private readonly IApplicationDbContext _context;

    public GetProjectTodosQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ProjectTodos> Handle(GetProjectTodosQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .Include(x => x.Client)
            .Include(x=>x.User)
            .ThenInclude(x=>x.Employee)
            .Include(x=>x.UserPM)
            .ThenInclude(x => x.Employee)
            .Include(x => x.Todos)
            .ThenInclude(x => x.UserFrom)
            .ThenInclude(x => x.Employee)
            .Include(x => x.Todos)
            .ThenInclude(x => x.UserTo)
            .ThenInclude(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        var todos = new ProjectTodos
        {
            Todos = project.Todos.Select(x => x.ToTodoDto()).OrderByDescending(x=>x.CreatedDate),
            Project = project.ToProjectDto()
        };
        return todos;
    }
}
