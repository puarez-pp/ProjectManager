namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public class ScheduleTaskEditVm
{
    public int? Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public string AssignedUserId { get; set; }
}
