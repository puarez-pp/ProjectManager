using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, ScheduleVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ICriticalPathService _criticalPath;

    public GetScheduleQueryHandler(IApplicationDbContext context,
        ICriticalPathService criticalPath)
    {
        _context = context;
        _criticalPath = criticalPath;
    }

    public async Task<ScheduleVm> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
    {
        var schedule = await _context.Schedules
            .Include(s => s.Stages)
                .ThenInclude(st => st.Tasks)
                    .ThenInclude(t => t.Dependencies)
            .FirstOrDefaultAsync(s => s.Id == request.Id);

        var allTasks = schedule.Stages.SelectMany(st => st.Tasks).ToList();
        var cpmResult = _criticalPath.CalculateDetailedCriticalPathDto(allTasks);

        var criticalIds = cpmResult.Tasks
            .Where(t => t.Slack == TimeSpan.Zero)
            .Select(t => t.TaskId)
            .ToHashSet();

        return new ScheduleVm
        {
            Id = schedule.Id,
            Name = schedule.Name,
            Comment = schedule.Comment,
            ProjectName = schedule.Project.Name,
            CreatedAt = schedule.CreatedAt,
            EditAt = schedule.EditAt,
            CriticalPath = cpmResult,
            Stages = schedule.Stages
                .OrderBy(st => st.Order)
                .Select(st => new ScheduleStageVm
                {
                    Id = st.Id,
                    Name = st.Name,
                    Order = st.Order,
                    PlannedStart = st.PlannedStart,
                    PlannedEnd = st.PlannedEnd,
                    Tasks = st.Tasks
                        .OrderBy(t => t.Order)
                        .Select(t => new ScheduleTaskVm
                        {
                            Id = t.Id,
                            Name = t.Name,
                            PlannedStart = t.PlannedStart,
                            PlannedEnd = t.PlannedEnd,
                            AssignedUser = $"{ t.AssignedUser.FirstName } { t.AssignedUser.LastName}",
                            IsCritical = criticalIds.Contains(t.Id),
                            Slack = cpmResult.Tasks
                                .First(x => x.TaskId == t.Id).Slack
                        }).ToList()
                }).ToList()
        };
    }
}
