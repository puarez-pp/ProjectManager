using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

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
            _context.DeviceParams.RemoveRange(_context.DeviceParams.Where(x => x.DeviceId == device.Id));
            _context.DeviceHeaders.RemoveRange(_context.DeviceHeaders.Where(x => x.DeviceId == device.Id));
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync(cancellationToken);
        }
            return Unit.Value;
    }
}
