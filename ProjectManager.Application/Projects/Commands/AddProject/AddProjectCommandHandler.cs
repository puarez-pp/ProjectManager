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
    private readonly IBackgroundWorkerQueue _backgroundWorker;

    public AddProjectCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService userService,
        IDateTimeService dateTimeService,
        IBackgroundWorkerQueue backgroundWorker)
    {
        _context = context;
        _userService = userService;
        _dateTimeService = dateTimeService;
        _backgroundWorker = backgroundWorker;
    }

    public async Task<Unit> Handle(AddProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project();
        project.Comment = request.Comment;
        project.Name = request.Name;
        project.Number = request.Number;
        project.ProjectType = request.ProjectType;
        project.Status = request.ProjectStatus;
        project.ClientId = 1;
        project.Sharepoint = request.Sharepoint;
        project.CreatedDate = _dateTimeService.Now;
        project.EditDate = _dateTimeService.Now;
        project.UserID = _userService.UserId;
        project.UserPMId = _userService.UserId;
        project.UserUpdatorId = _userService.UserId;
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync(cancellationToken);
        var projectId = project.Id;
        
        await AddDivision(projectId);
        await AddDivisionPositions(projectId);

        return Unit.Value;
    }

    private async Task AddDivision(int Id)
    {
        foreach (var divisionType in Enum.GetValues(typeof(DivisionType)))
        {
            var division = new Division();
            division.ProjectId = Id;
            division.DivisionType = (DivisionType)divisionType;
            division.UserId = _userService.UserId;
            await _context.Divisions.AddAsync(division);
        }
        await _context.SaveChangesAsync();

    }

    private async Task AddDivisionPositions(int Id)
    {
        var divisions = await _context
            .Divisions
            .Where(d => d.ProjectId == Id)
            .ToListAsync();
            
        foreach (var division in divisions)
        {
            foreach(var divisionPositionType in Enum.GetValues(typeof(DivisionPositionType)))
            {
                var divisionPosition = new DivisionPosition();
                divisionPosition.DivisionId = division.Id;
                divisionPosition.DivisionPositionType = (DivisionPositionType)divisionPositionType;
                divisionPosition.SubContractorId = 1;
                await _context.DivisionPositions.AddAsync(divisionPosition);
            }
        }
        await _context.SaveChangesAsync();
    }
}
