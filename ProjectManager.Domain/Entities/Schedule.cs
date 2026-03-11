using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Schedule
{
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public string Name { get; set; }
    public string Comment { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime EditAt { get; set; }

    public ICollection<ScheduleStage> Stages { get; set; } = new HashSet<ScheduleStage>();
}


public class ScheduleStage
{
    public int Id { get; set; }

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }


    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public ICollection<ScheduleTask> Tasks { get; set; } = new HashSet<ScheduleTask>();
}



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


public class TaskDependency
{
    public int Id { get; set; }

    public int PredecessorTaskId { get; set; }
    public ScheduleTask PredecessorTask { get; set; }

    public int SuccessorTaskId { get; set; }
    public ScheduleTask SuccessorTask { get; set; }

    public DependencyType Type { get; set; }
}


