using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public partial class ScheduleTaskVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public ScheduleStatus Status { get; set; }
    public string AssignedUser { get; set; }

    public bool IsCritical { get; set; }
    public TimeSpan Slack { get; set; }
}

public partial class ScheduleTaskVm
{
    public string StatusBootstrapClass
    {
        get
        {
            return Status switch
            {
                ScheduleStatus.Done => "success",
                ScheduleStatus.InProgress => "primary",
                ScheduleStatus.Planned => "secondary",
                ScheduleStatus.Blocked => "danger",
                _ => "light"
            };
        }
    }
}

