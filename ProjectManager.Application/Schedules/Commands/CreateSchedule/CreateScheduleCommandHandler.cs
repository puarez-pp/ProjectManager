using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public CreateScheduleCommandHandler(IApplicationDbContext context,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = new Schedule
        {
            ProjectId = request.ProjectId,
            Name = request.Name,
            Comment = request.Comment,
            CreatedAt = _dateTimeService.Now,
            EditAt = _dateTimeService.Now
        };
        await _context.Schedules.AddAsync(schedule);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}

