namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public class ScheduleEditVm
{
    public int? Id { get; set; }

    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }

    public List<ScheduleStageEditVm> Stages { get; set; } = new();
}
