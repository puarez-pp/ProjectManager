using MediatR;
using ProjectManager.Application.Schedules.Queries.GetScheduleDetails;

namespace ProjectManager.Application.Schedules.Queries.GetSchedules;

public class GetScheduleDetailsQuery : IRequest<ScheduleDetailsVm>
{
    public int Id { get; set; }
}
