using ProjectManager.Application.Schedules.Queries.Dto;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Common.Interfaces;

public interface ICriticalPathService
{
    List<ScheduleTask> CalculateCriticalPath(IEnumerable<ScheduleTask> tasks);
    CriticalPathResultDto CalculateDetailedCriticalPathDto(IEnumerable<ScheduleTask> tasks);
}
