using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Schedules.Queries.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedules;

public class SchedulesVm
{
    public ProjectBasicsDto Project { get; set; }
    public IList<ScheduleDto> Schedules { get; set; } = new List<ScheduleDto>();
}
