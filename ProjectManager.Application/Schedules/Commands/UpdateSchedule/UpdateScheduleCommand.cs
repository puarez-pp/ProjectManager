using MediatR;
using ProjectManager.Application.Schedules.Commands.CreateSchedule;

namespace ProjectManager.Application.Schedules.Commands.UpdateTaskStatus;

public class UpdateScheduleCommand : IRequest
{
    public ScheduleEditVm Model { get; set; }
}


