using MediatR;

namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public class GetScheduleQuery : IRequest<ScheduleVm>
{
    public int Id { get; set; }
}
