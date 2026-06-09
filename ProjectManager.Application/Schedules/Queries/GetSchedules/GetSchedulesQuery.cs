using MediatR;

namespace ProjectManager.Application.Schedules.Queries.GetSchedules;

public class GetSchedulesQuery : IRequest<SchedulesVm>
{
    public int Id { get; set; }
}
