using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class ScheduleTask
{
    public int Id { get; set; }

    public int StageId { get; set; }
    public ScheduleStage Stage { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }
    public bool IsMilestone => PlannedStart == PlannedEnd;


    public ScheduleStatus Status { get; set; }

    public string AssignedUserId { get; set; }
    public ApplicationUser AssignedUser { get; set; }

    public ICollection<TaskDependency> Dependencies { get; set; } = new HashSet<TaskDependency>();
    public ICollection<TaskDependency> Predecessors { get; set; } = new HashSet<TaskDependency>();
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}


