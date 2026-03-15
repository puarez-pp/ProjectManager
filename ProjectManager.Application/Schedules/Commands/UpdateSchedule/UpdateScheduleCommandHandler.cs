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
        var m = request.Model;

        var schedule = await _context.Schedules
            .Include(s => s.Stages)
                .ThenInclude(st => st.Tasks)
            .FirstOrDefaultAsync(s => s.Id == m.Id);

        if (schedule == null)
            throw new Exception("NIe znaleziono harmonogramu");

        // Aktualizacja pól prostych
        schedule.Name = m.Name;
        schedule.Comment = m.Comment;
        schedule.EditAt = _dateTimeService.Now;

        // Diffowanie STAGES

        // istniejące etapy
        var existingStages = schedule.Stages.ToDictionary(s => s.Id);

        // ID etapów z formularza
        var incomingStageIds = m.Stages.Where(s => s.Id.HasValue).Select(s => s.Id.Value).ToHashSet();

        // 2.1 Usuwanie etapów, które zniknęły
        var stagesToRemove = schedule.Stages
            .Where(s => !incomingStageIds.Contains(s.Id))
            .ToList();

        foreach (var st in stagesToRemove)
            _context.ScheduleStages.Remove(st);

        // Aktualizacja i dodawanie etapów
        foreach (var stageVm in m.Stages)
        {
            ScheduleStage stage;

            if (stageVm.Id.HasValue)
            {
                // aktualizacja istniejącego
                stage = existingStages[stageVm.Id.Value];
            }
            else
            {
                // nowy etap
                stage = new ScheduleStage
                {
                    ScheduleId = schedule.Id
                };
                schedule.Stages.Add(stage);
            }

            stage.Name = stageVm.Name;
            stage.Description = stageVm.Description;
            stage.Order = stageVm.Order;
            stage.PlannedStart = stageVm.PlannedStart;
            stage.PlannedEnd = stageVm.PlannedEnd;

            //Diffowanie TASKS w etapie

            var existingTasks = stage.Tasks.ToDictionary(t => t.Id);
            var incomingTaskIds = stageVm.Tasks.Where(t => t.Id.HasValue).Select(t => t.Id.Value).ToHashSet();

            // 3.1 Usuwanie zadań, które zniknęły
            var tasksToRemove = stage.Tasks
                .Where(t => !incomingTaskIds.Contains(t.Id))
                .ToList();

            foreach (var t in tasksToRemove)
                _context.ScheduleTasks.Remove(t);

            // 3.2 Aktualizacja i dodawanie zadań
            foreach (var taskVm in stageVm.Tasks)
            {
                ScheduleTask task;

                if (taskVm.Id.HasValue)
                {
                    // aktualizacja istniejącego
                    task = existingTasks[taskVm.Id.Value];
                }
                else
                {
                    // nowe zadanie
                    task = new ScheduleTask
                    {
                        StageId = stage.Id,
                        CreatedAt = _dateTimeService.Now,
                        Status = ScheduleStatus.Planned
                    };
                    stage.Tasks.Add(task);
                }

                task.Name = taskVm.Name;
                task.Description = taskVm.Description;
                task.Order = taskVm.Order;
                task.PlannedStart = taskVm.PlannedStart;
                task.PlannedEnd = taskVm.PlannedEnd;
                task.AssignedUserId = taskVm.AssignedUserId;
                task.UpdatedAt = DateTime.UtcNow;
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;

    }
}


