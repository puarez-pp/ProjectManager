using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class TaskDependency
{
    public int Id { get; set; }

    public int PredecessorTaskId { get; set; }
    public ScheduleTask PredecessorTask { get; set; }

    public int SuccessorTaskId { get; set; }
    public ScheduleTask SuccessorTask { get; set; }

    public DependencyType Type { get; set; }
}


