using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Commands.UpdateTaskStatus;

public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _userService;
    private readonly IDateTimeService _dateTimeService;

    public UpdateScheduleCommandHandler(IApplicationDbContext context,
        ICurrentUserService userService,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _userService = userService;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await _context.Schedules
            .Include(s => s.Stages)
                .ThenInclude(st => st.Tasks)
                    .ThenInclude(t => t.Dependencies)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (schedule == null)
            throw new KeyNotFoundException($"Schedule {request.Id} not found.");

        var dto = request.Dto;

        schedule.Name = dto.Name;
        schedule.Comment = dto.Comment;
        schedule.EditAt = DateTime.UtcNow;

        // --- Aktualizacja Stage ---
        var dtoStageIds = dto.Stages.Where(s => s.Id.HasValue).Select(s => s.Id.Value).ToList();
        var existingStageIds = schedule.Stages.Select(s => s.Id).ToList();

        // usuwanie
        foreach (var stage in schedule.Stages.Where(s => !dtoStageIds.Contains(s.Id)).ToList())
            _context.ScheduleStages.Remove(stage);

        // aktualizacja + dodawanie
        foreach (var stageDto in dto.Stages)
        {
            ScheduleStage stage;

            if (stageDto.Id.HasValue)
            {
                stage = schedule.Stages.First(s => s.Id == stageDto.Id.Value);
            }
            else
            {
                stage = new ScheduleStage();
                schedule.Stages.Add(stage);
            }

            stage.Name = stageDto.Name;
            stage.Description = stageDto.Description;
            stage.Order = stageDto.Order;
            stage.PlannedStart = stageDto.PlannedStart;
            stage.PlannedEnd = stageDto.PlannedEnd;

            // --- Aktualizacja Task ---
            var dtoTaskIds = stageDto.Tasks.Where(t => t.Id.HasValue).Select(t => t.Id.Value).ToList();
            var existingTaskIds = stage.Tasks.Select(t => t.Id).ToList();

            // usuwanie
            foreach (var task in stage.Tasks.Where(t => !dtoTaskIds.Contains(t.Id)).ToList())
                _context.ScheduleTasks.Remove(task);

            // aktualizacja + dodawanie
            foreach (var taskDto in stageDto.Tasks)
            {
                ScheduleTask task;

                if (taskDto.Id.HasValue)
                {
                    task = stage.Tasks.First(t => t.Id == taskDto.Id.Value);
                }
                else
                {
                    task = new ScheduleTask
                    {
                        CreatedAt = DateTime.UtcNow
                    };
                    stage.Tasks.Add(task);
                }

                task.Name = taskDto.Name;
                task.Description = taskDto.Description;
                task.Order = taskDto.Order;
                task.PlannedStart = taskDto.PlannedStart;
                task.PlannedEnd = taskDto.PlannedEnd;
                task.AssignedUserId = taskDto.AssignedUserId;
                task.Status = taskDto.Status;
                task.UpdatedAt = DateTime.UtcNow;

                // zależności — najpierw czyścimy
                _context.TaskDependencies.RemoveRange(task.Dependencies);

                // dodajemy nowe
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
        return Unit.Value;

    }
}


