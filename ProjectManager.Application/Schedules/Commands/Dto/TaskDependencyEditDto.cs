using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Commands.Dto;

public class TaskDependencyEditDto
{
    public int PredecessorTaskId { get; set; }
    public DependencyType Type { get; set; }
}
