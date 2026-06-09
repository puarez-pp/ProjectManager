namespace ProjectManager.Application.Schedules.Queries.Dto;

public class CriticalPathResultDto
{
    public List<CriticalPathTaskDto> Tasks { get; set; } = new();

    public TimeSpan TotalDuration { get; set; }
    public int? FirstTaskId { get; set; }
    public int? LastTaskId { get; set; }
}
