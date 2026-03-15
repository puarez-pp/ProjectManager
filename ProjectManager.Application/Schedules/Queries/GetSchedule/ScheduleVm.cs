using ProjectManager.Application.Schedules.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public class ScheduleVm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public string ProjectName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime EditAt { get; set; }

    public List<ScheduleStageVm> Stages { get; set; } = new();

    public CriticalPathResultDto CriticalPath { get; set; }
}

