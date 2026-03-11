namespace ProjectManager.Application.Schedules.Dto;

public class StageDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }
    public List<TaskDto> Tasks { get; set; } = new();
}


