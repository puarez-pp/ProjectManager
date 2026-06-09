using MediatR;
using ProjectManager.Application.Schedules.Commands.Dto;

namespace ProjectManager.Application.Schedules.Commands.UpdateTaskStatus;

public record UpdateScheduleCommand(int Id, ScheduleEditDto Dto) : IRequest;



