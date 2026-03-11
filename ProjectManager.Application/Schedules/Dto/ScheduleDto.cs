namespace ProjectManager.Application.Schedules.Dto;

public class ScheduleDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public List<StageDto> Stages { get; set; } = new();
}
