using MediatR;
using ProjectManager.Application.Schedules.Commands.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetEditSchedule;

public class GetEditScheduleQuery : IRequest<ScheduleEditDto>
{
    public int Id { get; set; }
}
