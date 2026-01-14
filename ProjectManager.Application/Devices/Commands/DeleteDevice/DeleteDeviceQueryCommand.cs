using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Devices.Commands.DeleteDevice;

public class DeleteDeviceQueryCommand : IRequestHandler<DeleteDeviceCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteDeviceQueryCommand(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await _context
            .Devices
            .FirstOrDefaultAsync(d => d.Id == request.Id);
        if (device != null)
        {
            switch(device.DeviceType)
            {
                case DeviceType.Engine:
                    _context.Engines.RemoveRange(_context.Engines.Where(x => x.DeviceId == device.Id));
                    break;
                case DeviceType.GasCounter:
                    _context.GasCounters.RemoveRange(_context.GasCounters.Where(x => x.DeviceId == device.Id));
                    break;
                case DeviceType.HeatCounter:
                    _context.HeatCounters.RemoveRange(_context.HeatCounters.Where(x => x.DeviceId == device.Id));
                    break;
                case DeviceType.ElectricCounter:
                    _context.ElectricCounters.RemoveRange(_context.ElectricCounters.Where(x => x.DeviceId == device.Id));
                    break;
                case DeviceType.Other:
                    _context.OtherCounters.RemoveRange(_context.OtherCounters.Where(x => x.DeviceId == device.Id));
                    break;
            }
            _context.DeviceHeaders.RemoveRange(_context.DeviceHeaders.Where(x => x.DeviceId == device.Id));
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync(cancellationToken);
        }
            return Unit.Value;
    }
}
