using MediatR;
using ProjectManager.Application.Schedules.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public class GetScheduleQuery : IRequest<ScheduleDto>
{
    public int Id { get; set; }
}
