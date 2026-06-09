namespace ProjectManager.Application.Schedules.Commands.Dto;

public class ScheduleEditDto
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }

    public List<ScheduleStageEditDto> Stages { get; set; } = new();
}
