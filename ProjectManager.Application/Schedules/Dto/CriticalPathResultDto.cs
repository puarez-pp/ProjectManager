namespace ProjectManager.Application.Schedules.Dto;

public class CriticalPathResultDto
{
    public List<CriticalPathTaskDto> Tasks { get; set; } = new();

    // Dodatkowe informacje dla UI
    public TimeSpan TotalDuration { get; set; }
    public int? FirstTaskId { get; set; }
    public int? LastTaskId { get; set; }
}
