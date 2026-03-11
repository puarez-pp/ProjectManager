using ProjectManager.Application.Schedules.CriticalPath;
using ProjectManager.Application.Schedules.Dto;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Common.Interfaces;

public interface ICriticalPathService
{
    List<ScheduleTask> CalculateCriticalPath(IEnumerable<ScheduleTask> tasks);
    CriticalPathResult CalculateDetailedCriticalPath(IEnumerable<ScheduleTask> tasks);
    CriticalPathResultDto CalculateDetailedCriticalPathDto(IEnumerable<ScheduleTask> tasks);
}
