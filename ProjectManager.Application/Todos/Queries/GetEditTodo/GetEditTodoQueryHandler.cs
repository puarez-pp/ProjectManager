using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
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
            .Where(x => x.Todos.Any(x=>x.Id == request.Id))
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

        var todo = await _context
            .Todos
            .Where(x => x.Id == request.Id)
            .Select(x => new EditTodoCommand
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                Title = x.Title,
                Body = x.Body,
                CompletionDate = x.CompletionDate,
                UserToId = x.UserToId,
            }).FirstOrDefaultAsync(cancellationToken);

        var vm = new EditTodoVm
        {
            Project = project,
            AvaiableUsers = users,
            Todo = todo
        };
        return vm;
    }
}
