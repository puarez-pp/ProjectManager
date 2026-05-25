using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using System.Linq.Dynamic.Core;

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
            .Include(d=>d.DeviceHeaders)
            .FirstOrDefaultAsync(d => d.Id == request.Id);
        var devType = device.DeviceType;
        if (device != null)
        {
            device.Name = request.Name;
            device.Description = request.Description;
            device.DeviceType = request.DeviceType;
            if (devType != request.DeviceType)
            {
               _context.DeviceHeaders.RemoveRange(device.DeviceHeaders);
                var template = await _context
                    .DeviceTemplates
                    .AsNoTracking()
                    .Include(t => t.TemplatePositions)
                    .FirstOrDefaultAsync(t => t.DeviceType == request.DeviceType);

                foreach (var pos in template.TemplatePositions.OrderBy(p => p.Order))
                {
                    device.DeviceHeaders.Add(new DeviceHeader
                    {
                        Name = pos.Name,
                        Description = pos.Description,
                        Order = pos.Order
                    });
                }
            }
            await _context.SaveChangesAsync();
        }
        
        return Unit.Value;
    }

    private DeviceHeader[] GetDeviceHeaders(int id)
    { 
        return _context
            .DeviceHeaders
            .Where(x => x.DeviceId == id).ToArray();
    }
}
