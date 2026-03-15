using MediatR;
using ProjectManager.Application.Schedules.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedules;

public class GetSchedulesQuery : IRequest<List<ScheduleDto>>
{
    public int ProjectId { get; set; }
}
