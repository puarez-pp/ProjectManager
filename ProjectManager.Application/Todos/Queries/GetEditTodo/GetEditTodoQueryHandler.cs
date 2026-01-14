using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Todos.Commands.EditTodo;
using ProjectManager.Application.Users.Extensions;

namespace ProjectManager.Application.Todos.Queries.GetEditTodo;

public class GetEditTodoQueryHandler : IRequestHandler<GetEditTodoQuery, EditTodoVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditTodoQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditTodoVm> Handle(GetEditTodoQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Include(x => x.Client)
            .Include(x => x.User)
            .ThenInclude(x => x.Employee)
            .Include(x=>x.Todos)
            .ThenInclude(x=>x.UserFrom)
            .ThenInclude(x=>x.Employee)
            .Include(x=>x.Todos)
            .ThenInclude(x=>x.UserTo)
            .ThenInclude(x=>x.Employee)
            .FirstOrDefaultAsync(x => x.Todos.Any(x=>x.Id == request.Id));

        var vm = new EditTodoVm();
        vm.Project = project.ToProjectDto();
        vm.Todo = new EditTodoCommand
        {
            Id = request.Id,
            ProjectId = project.Todos.FirstOrDefault(x=>x.Id == request.Id).ProjectId,
            Title = project.Todos.FirstOrDefault(x => x.Id == request.Id).Title,
            Content = project.Todos.FirstOrDefault(x => x.Id == request.Id).Content,
            UserToId = project.Todos.FirstOrDefault(x => x.Id == request.Id).UserToId
        };
        vm.AvaiableUsers = await _context
            .Users
            .Include(x => x.Employee)
            .Select(x => x.ToUserDto())
            .ToListAsync();
        return vm;
    }
}
