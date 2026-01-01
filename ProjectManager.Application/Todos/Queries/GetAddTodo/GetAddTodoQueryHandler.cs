using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
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
            .Include(x => x.Client)
            .Include(x => x.User)
            .ThenInclude(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        var vm = new AddTodoVm();
        vm.Project = project.ToProjectDto();
        vm.Todo = new AddTodoCommand
        {
            ProjectId = request.Id,
        };
        vm.AvaiableUsers = await _context
            .Users
            .Include(x => x.Employee)
            .Select(x => x.ToUserDto())
            .ToListAsync();
        return vm;

    }
}
