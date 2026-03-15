using MediatR;

namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public class CreateScheduleCommand : IRequest
{
    public ScheduleEditVm Model { get; set; }
}

