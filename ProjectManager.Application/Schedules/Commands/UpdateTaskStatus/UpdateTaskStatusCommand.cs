using MediatR;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Commands.UpdateTaskStatus;

public class UpdateTaskStatusCommand : IRequest
{
    public int TaskId { get; set; }
    public ScheduleStatus Status { get; set; }
}


