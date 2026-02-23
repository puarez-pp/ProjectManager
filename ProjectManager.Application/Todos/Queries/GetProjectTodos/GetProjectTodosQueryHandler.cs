using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class GetProjectTodosQueryHandler : IRequestHandler<GetProjectTodosQuery, ProjectTodosVm>
{
    private readonly IApplicationDbContext _context;

    public GetProjectTodosQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ProjectTodosVm> Handle(GetProjectTodosQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
           .Projects
           .AsNoTracking()
           .Where(x => x.Id == request.Id)
           .Select(x => new ProjectBasicsDto
           {
               Id = request.Id,
               Number = x.Number,
               Name = x.Name,
           })       
           .FirstOrDefaultAsync ();

        var todos = await _context
            .Todos
            .AsNoTracking()
            .Where(x => x.ProjectId == request.Id)
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
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
        
        var vm = new ProjectTodosVm();
        vm.Project = project;
        vm.Todos = request.ShowAll ? todos : todos.Where(x => !x.IsCompleted).ToList();
        return vm;
    }
}
