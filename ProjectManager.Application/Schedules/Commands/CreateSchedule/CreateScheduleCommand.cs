using MediatR;
using ProjectManager.Application.Schedules.Commands.Dto;

namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public record CreateScheduleCommand(ScheduleEditDto Dto) : IRequest<int>;

