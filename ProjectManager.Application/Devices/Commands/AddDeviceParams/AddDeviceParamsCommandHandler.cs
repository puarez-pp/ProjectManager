using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Devices.Commands.AddDeviceParams;

public class AddDeviceParamsCommandHandler : IRequestHandler<AddDeviceParamsCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTime;

    public AddDeviceParamsCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTime)
    {
        _context = context;
        _dateTime = dateTime;
    }

    public async Task<Unit> Handle(AddDeviceParamsCommand request, CancellationToken cancellationToken)
    {
        var timeStamp = _dateTime.Now;  
        foreach (var param in request.DeviceParams)
        {
            var entity = new DeviceParam
            {
                Id = Guid.NewGuid(),
                TimeStamp = timeStamp,
                DeviceId = request.DeviceId,
                Name = param.Name,
                Value = param.Value
            };
            await _context.DeviceParams.AddAsync(entity, cancellationToken);
        }
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}


