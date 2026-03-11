using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Dto;

public class TaskDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ScheduleStatus Status { get; set; }
    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }
}


