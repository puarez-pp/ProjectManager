using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Queries.GetScheduleDetails;

public class ScheduleTaskDetailsVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public bool IsMilestone { get; set; }

    public ScheduleStatus Status { get; set; }

    public string AssignedUserId { get; set; }
    public string AssignedUserName { get; set; }

    public List<int> PredecessorIds { get; set; } = new();
    public List<int> SuccessorIds { get; set; } = new();
}

