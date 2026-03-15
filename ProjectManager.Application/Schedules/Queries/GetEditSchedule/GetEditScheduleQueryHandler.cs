
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Schedules.Commands.CreateSchedule;

namespace ProjectManager.Application.Schedules.Queries.GetAddSchedule;

public class GetEditScheduleQueryHandler : IRequestHandler<GetEditScheduleQuery, ScheduleEditVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditScheduleQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ScheduleEditVm> Handle(GetEditScheduleQuery request, CancellationToken cancellationToken)
    {
        var schedule = await _context
            .Schedules
            .Include(s => s.Stages)
                .ThenInclude(st => st.Tasks)
            .FirstOrDefaultAsync(s => s.Id == request.Id);

        if (schedule == null)
            throw new Exception("Nie znaleziono harmonogramu");

        var vm = new ScheduleEditVm
        {
            Id = schedule.Id,
            ProjectId = schedule.ProjectId,
            Name = schedule.Name,
            Comment = schedule.Comment,
            Stages = schedule.Stages
                .OrderBy(st => st.Order)
                .Select(st => new ScheduleStageEditVm
                {
                    Id = st.Id,
                    Name = st.Name,
                    Description = st.Description,
                    Order = st.Order,
                    PlannedStart = st.PlannedStart,
                    PlannedEnd = st.PlannedEnd,

                    Tasks = st.Tasks
                        .OrderBy(t => t.Order)
                        .Select(t => new ScheduleTaskEditVm
                        {
                            Id = t.Id,
                            Name = t.Name,
                            Description = t.Description,
                            Order = t.Order,
                            PlannedStart = t.PlannedStart,
                            PlannedEnd = t.PlannedEnd,
                            AssignedUserId = t.AssignedUserId
                        })
                        .ToList()
                })
                .ToList()
        };

        return vm;
    }
}
