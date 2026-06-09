using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Commands.Dto;

public class ScheduleTaskEditDto
{
    public int? Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public string AssignedUserId { get; set; }
    public ScheduleStatus Status { get; set; }

    public List<TaskDependencyEditDto> Dependencies { get; set; } = new();
}
