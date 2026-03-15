using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _userService;

    public CreateScheduleCommandHandler(IApplicationDbContext context,
        IDateTimeService dateTimeService,
        ICurrentUserService userService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _userService = userService;
    }
    public async Task<Unit> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var m = request.Model;

        var schedule = new Schedule
        {
            ProjectId = m.ProjectId,
            Name = m.Name,
            Comment = m.Comment,
            UserId = _userService.UserId,
            CreatedAt = _dateTimeService.Now,
            EditAt = _dateTimeService.Now
        };

        foreach (var stageVm in m.Stages.OrderBy(s => s.Order))
        {
            var stage = new ScheduleStage
            {
                Name = stageVm.Name,
                Description = stageVm.Description,
                Order = stageVm.Order,
                PlannedStart = stageVm.PlannedStart,
                PlannedEnd = stageVm.PlannedEnd
            };

            foreach (var taskVm in stageVm.Tasks.OrderBy(t => t.Order))
            {
                stage.Tasks.Add(new ScheduleTask
                {
                    Name = taskVm.Name,
                    Description = taskVm.Description,
                    Order = taskVm.Order,
                    PlannedStart = taskVm.PlannedStart,
                    PlannedEnd = taskVm.PlannedEnd,
                    Status = ScheduleStatus.Planned,
                    CreatedAt = _dateTimeService.Now
                });
            }

            schedule.Stages.Add(stage);
        }

        await _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

