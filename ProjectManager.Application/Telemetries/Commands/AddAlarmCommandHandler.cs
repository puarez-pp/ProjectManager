using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Telemetries.Commands;

public class AddAlarmCommandHandler : IRequestHandler<AddAlarmCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public AddAlarmCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(AddAlarmCommand request, CancellationToken cancellationToken)
    {
        var alarm = new Alarm
        {
            Id = Guid.NewGuid(),
            AlarmType = request.AlarmType,
            DeviceId = request.DeviceId,
            Name = request.Name,
            TimeStamp = request.TimeStamp,
        };
        await _context.Alarms.AddAsync(alarm);
        await _context.SaveChangesAsync();
        return alarm.Id;
    }
}
