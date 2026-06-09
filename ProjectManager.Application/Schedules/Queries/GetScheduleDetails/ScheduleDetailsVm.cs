using ProjectManager.Application.Schedules.Queries.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetScheduleDetails;

public class ScheduleDetailsVm
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Comment { get; set; }

    public List<ScheduleStageDetailsVm> Stages { get; set; } = new();

    // Wynik CPM
    public CriticalPathResultDto CriticalPath { get; set; }
}

