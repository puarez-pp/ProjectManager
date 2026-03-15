using MediatR;
using ProjectManager.Application.Schedules.Dto;
using System.Threading.Tasks;

namespace ProjectManager.Application.Schedules.CriticalPath;

public class GetCriticalPathQuery : IRequest<CriticalPathResultDto>
{
    public int ScheduleId { get; set; }
}
