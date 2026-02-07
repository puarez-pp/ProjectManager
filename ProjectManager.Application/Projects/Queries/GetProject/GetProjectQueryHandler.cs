using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Projects.Queries.GetProject;

public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, GetProjectVm>
{
    private readonly IApplicationDbContext _context;

    public GetProjectQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetProjectVm> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
           .Projects
           .AsNoTracking()
           .Where(x => x.Id == request.Id)
           .Select(x => new ProjectDto
           {
               Id = request.Id,
               ProjectType = x.ProjectType.GetDisplayName(),
               ProjectStatus = x.Status,
               Number = x.Number,
               Name = x.Name,
               Sharepoint = x.Sharepoint,
               Comment = x.Comment,
               User = new UserDto
               {
                   FullName = $"{x.User.FirstName} {x.User.LastName}",
                   Employee = new EmployeeDto { }
               },
               UserUpd = new UserDto
               {
                   FullName = $"{x.UserUpdator.FirstName} {x.UserUpdator.LastName}",
                   Employee = new EmployeeDto { }
               },
               ProjectManager = new UserDto
               {
                   FullName = $"{x.UserPM.FirstName} {x.UserPM.LastName}",
                   Employee = new EmployeeDto { }
               },
               DesignEng = new UserDto
               {
                   FullName = $"{x.DesignEng.FirstName} {x.DesignEng.LastName}",
                   Employee = new EmployeeDto { }
               },
               ElectricEng = new UserDto
               {
                   FullName = $"{x.ElectricEng.FirstName} {x.ElectricEng.LastName}",
                   Employee = new EmployeeDto { }
               },
               Client = x.Client.Name,
               CreatedAt = x.CreatedAt,
               EditdAt = x.EditAt,
               FinishedAt = x.FinishedAt,
               Scopes = x.ProjectScopes
                .OrderBy(s => s.Order)
                .Select(s => new ProjectScopeDto
                {
                    Id = s.Id,
                    Description = s.Description,
                    Positions = s.Positions
                        .OrderBy(p => p.Order)
                        .Select(p => new ProjectScopePositionDto
                        {
                            Id = p.Id,
                            Description = p.Description,
                            IsCompleted = p.IsCompleted,
                            NotApplicable = p.NotApplicable,
                            CompletionDate = p.CompletionDate,
                        })
                        .ToList()
                })
                .ToList()

           })
           .SingleOrDefaultAsync();

           

        var vm = new GetProjectVm
        {
            Project = project,
        };
        return vm;      
    }  
}
