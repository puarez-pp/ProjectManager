using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class GetProjectTodosQueryHandler : IRequestHandler<GetProjectTodosQuery, ProjectTodosVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProjectTodosQueryHandler(IApplicationDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProjectTodosVm> Handle(GetProjectTodosQuery request, CancellationToken cancellationToken)
    {
        const int pageSize = 5;
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
            .OrderByDescending(x => x.CreatedAt)
            .ProjectTo<TodoDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageIndex, pageSize);


        var vm = new ProjectTodosVm();
        vm.Project = project;
        vm.Todos = todos;
        return vm;
    }
}
