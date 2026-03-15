
using MediatR;
using ProjectManager.Application.Schedules.Commands.CreateSchedule;

namespace ProjectManager.Application.Schedules.Queries.GetAddSchedule;

public class GetEditScheduleQuery : IRequest<ScheduleEditVm>
{
    public int Id { get; set; }
}
