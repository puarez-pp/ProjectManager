namespace ProjectManager.Application.Schedules.Queries.GetScheduleDetails;

public class ScheduleStageDetailsVm
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public List<ScheduleTaskDetailsVm> Tasks { get; set; } = new();
}

