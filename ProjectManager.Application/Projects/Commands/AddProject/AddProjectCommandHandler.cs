using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Commands.AddProject;

public class AddProjectCommandHandler : IRequestHandler<AddProjectCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _userService;
    private readonly IDateTimeService _dateTimeService;

    public AddProjectCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService userService,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _userService = userService;
        _dateTimeService = dateTimeService;
    }

    public async Task<Unit> Handle(AddProjectCommand request, CancellationToken cancellationToken)
    {
        var projectType = ProjectType.Gas;
        // 1. Pobranie szablonów
        var templates = await _context
            .ProjectScopeTemplates
            .Include(x => x.ProjectScopePositions)
            .Where(x => x.ProjectType == projectType)
            .OrderBy(x => x.Order)
            .ToListAsync();

        if (!templates.Any())
            throw new InvalidOperationException("Brak szablonów dla podanego typu projektu.");

        // 2. Utworzenie Project
        var project = new Project
        {
            Comment = request.Comment,
            Name = request.Name,
            Number = request.Number,
            ProjectType = request.ProjectType,
            Status = request.ProjectStatus,
            ClientId = 1,
            Sharepoint = request.Sharepoint,
            CreatedAt = _dateTimeService.Now,
            EditAt = _dateTimeService.Now,
            UserID = _userService.UserId,
            UserPMId = _userService.UserId,
            UserUpdatorId = _userService.UserId,
            DesignEngId = _userService.UserId,
            ElectricEngId = _userService.UserId,
        };

        // 3. Tworzenie ProjectScope na podstawie szablonów
        foreach (var template in templates)
        {
            var projectScope = new ProjectScope
            {
                Description = template.Description,
                Order = template.Order
            };

            // 4. Tworzenie pozycji ProjectScope
            foreach (var pos in template.ProjectScopePositions.OrderBy(p => p.Order))
            {
                projectScope.Positions.Add(new ProjectScopePosition
                {
                    Description = pos.Description,
                    Order = pos.Order,
                });
            }
            project.ProjectScopes.Add(projectScope);
        }
        // 5. Zapis do bazy
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
