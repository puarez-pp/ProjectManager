using MediatR;
using ProjectManager.Application.Schedules.Queries.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public class GetScheduleCriticalPathQuery : IRequest<CriticalPathResultDto>
{
    public int Id { get; set; }
}
