using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUser;

    public CreateScheduleCommandHandler(IApplicationDbContext context,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUser)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _currentUser = currentUser;
    }
    public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var schedule = new Schedule
        {
            ProjectId = dto.ProjectId,
            Name = dto.Name,
            Comment = dto.Comment,
            UserId = _currentUser.UserId,
            CreatedAt = DateTime.UtcNow,
            EditAt = DateTime.UtcNow
        };

        foreach (var stageDto in dto.Stages)
        {
            var stage = new ScheduleStage
            {
                Name = stageDto.Name,
                Description = stageDto.Description,
                Order = stageDto.Order,
                PlannedStart = stageDto.PlannedStart,
                PlannedEnd = stageDto.PlannedEnd
            };

            foreach (var taskDto in stageDto.Tasks)
            {
                var task = new ScheduleTask
                {
                    Name = taskDto.Name,
                    Description = taskDto.Description,
                    Order = taskDto.Order,
                    PlannedStart = taskDto.PlannedStart,
                    PlannedEnd = taskDto.PlannedEnd,
                    AssignedUserId = taskDto.AssignedUserId,
                    Status = taskDto.Status,
                    CreatedAt = DateTime.UtcNow
                };

                stage.Tasks.Add(task);
            }

            schedule.Stages.Add(stage);
        }

        _context.Schedules.Add(schedule);
        await _context.SaveChangesAsync(cancellationToken);

        foreach (var stageDto in dto.Stages)
        {
            foreach (var taskDto in stageDto.Tasks)
            {
                var task = schedule.Stages
                    .SelectMany(s => s.Tasks)
                    .First(t => t.Name == taskDto.Name && t.Order == taskDto.Order);

                foreach (var depDto in taskDto.Dependencies)
                {
                    _context.TaskDependencies.Add(new TaskDependency
                    {
                        PredecessorTaskId = depDto.PredecessorTaskId,
                        SuccessorTaskId = task.Id,
                        Type = depDto.Type
                    });
                }
            }
        }

        await _context.SaveChangesAsync(cancellationToken);

        return schedule.Id;
    }
}

