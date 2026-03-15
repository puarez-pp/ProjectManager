namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public class ScheduleStageVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }
    public List<ScheduleTaskVm> Tasks { get; set; } = new();
}

