namespace ProjectManager.Application.Schedules.Commands.Dto;

public class ScheduleStageEditDto
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public List<ScheduleTaskEditDto> Tasks { get; set; } = new();
}
