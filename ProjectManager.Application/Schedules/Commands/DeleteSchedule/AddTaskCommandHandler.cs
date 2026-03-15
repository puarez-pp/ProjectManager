using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Schedules.Commands.AddTask;

public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _timeService;

    public AddTaskCommandHandler(IApplicationDbContext context,
        IDateTimeService timeService)
    {
        _context = context;
        _timeService = timeService;
    }
    public async Task<Unit> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new ScheduleTask
        {
            StageId = request.StageId,
            Name = request.Name,
            Description = request.Description,
            Status = ScheduleStatus.Planned,
            CreatedAt = _timeService.Now,
            UpdatedAt = _timeService.Now,
        };
        await _context.ScheduleTasks.AddAsync(task);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

