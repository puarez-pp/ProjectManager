using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Common.Interfaces;

public interface ICriticalPathMethod
{
    List<Activity> WalkListAhead(List<Activity> activities);
    List<Activity> WalkListAback(List<Activity> activities);
    void CriticalPath(List<Activity> activities);
}