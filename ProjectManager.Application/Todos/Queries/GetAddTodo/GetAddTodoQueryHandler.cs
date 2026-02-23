using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Todos.Commands.AddTodo;
using ProjectManager.Application.Users.Extensions;

namespace ProjectManager.Application.Todos.Queries.GetAddTodo;

public class GetAddTodoQueryHandler : IRequestHandler<GetAddTodoQuery, AddTodoVm>
{
    private readonly IApplicationDbContext _context;

    public GetAddTodoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<AddTodoVm> Handle(GetAddTodoQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(x => new ProjectBasicsDto
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
            })
            .FirstOrDefaultAsync(cancellationToken);

        var users = await _context
            .Users
            .Include(x => x.Employee)
            .AsNoTracking()
            .Select(x => x.ToUserDto())
            .ToListAsync();

        var vm = new AddTodoVm
        {
            Project = project,
            Todo = new AddTodoCommand
            {
                ProjectId = request.Id,
            },
             AvaiableUsers = users,
        };
        return vm;
    }
}
