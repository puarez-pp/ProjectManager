using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Devices.Commands.EditDevice;

public class EditDeviceCommandHandler : IRequestHandler<EditDeviceCommand>
{
    private readonly IApplicationDbContext _context;

    public EditDeviceCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = await _context
            .Devices
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
        var devType = device?.DeviceType;
        if (device != null)
        {        
            device.Name = request.Name;
            device.Description = request.Description;
            device.DeviceType = request.DeviceType;
            await _context.SaveChangesAsync();
            if (devType != request.DeviceType)
            {
                _context.DeviceHeaders.RemoveRange(GetDeviceHeaders(device.Id));
                await AddDeviceHeaders(device.Id, request.DeviceType);
                await _context.SaveChangesAsync();
            }
        }
        return Unit.Value;
    }

    private DeviceHeader[] GetDeviceHeaders(int id)
    { 
        return _context
            .DeviceHeaders
            .Where(x => x.DeviceId == id).ToArray();
    }
    private async Task AddDeviceHeaders(int devicetId, DeviceType deviceType)
    {
        var temps = await _context
            .Templates
            .Include(x => x.TemplatePositions)
            .Where(x => x.DeviceType == deviceType)
            .ToListAsync();
        var headers = temps.Select(x => x.TemplatePositions).ToArray();

        foreach (var header in headers)
        {
            var devHeader = new DeviceHeader
            {
                DeviceId = devicetId,
                Name = header.Select(x => x.Name).ToString(),
                Description = header.Select(x => x.Description).ToString(),
                Order = header.Select(x => x.Order).FirstOrDefault()
            };
            _context.DeviceHeaders.Add(devHeader);
        }
    }
}
