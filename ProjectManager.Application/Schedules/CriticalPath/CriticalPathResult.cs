using ProjectManager.Application.Schedules.Dto;

namespace ProjectManager.Application.Schedules.CriticalPath;

public class CriticalPathResult
{
    public List<CriticalPathTaskDto> Tasks { get; set; } = new();
}
