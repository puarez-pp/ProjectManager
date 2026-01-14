using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;

public class EditDeviceHeaderCommandHandler : IRequestHandler<EditDeviceHeaderCommand>
{
    private readonly IApplicationDbContext _context;

    public EditDeviceHeaderCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditDeviceHeaderCommand request, CancellationToken cancellationToken)
    {
        var device = await _context
            .DeviceHeaders
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
        if (device != null)
        {
            device.Name = request.Name;
            device.Description = request.Description;
            device.Used = request.Used;
            await _context.SaveChangesAsync(cancellationToken);
        }
            return Unit.Value;
    }
}
