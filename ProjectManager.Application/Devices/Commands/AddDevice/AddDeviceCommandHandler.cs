using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.Application.Devices.Commands.AddDevice;

public class AddDeviceCommandHandler : IRequestHandler<AddDeviceCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _userService;
    private readonly IDateTimeService _timeService;

    public AddDeviceCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService userService,
        IDateTimeService timeService)
    {
        _context = context;
        _userService = userService;
        _timeService = timeService;
    }
    public async Task<Unit> Handle(AddDeviceCommand request, CancellationToken cancellationToken)
    {
        var device = new Device
        {
            PlantId = request.PlantId,
            Name = request.Name,
            Description = request.Description,
            DeviceType = request.DeviceType,
            UserId = _userService.UserId,
            CreatedDate = _timeService.Now
        };
        _context.Devices.Add(device);
        await _context.SaveChangesAsync(cancellationToken);
        var devicetId = device.Id;
        await AddDeviceHeaders(devicetId, device.DeviceType);
        return Unit.Value;
    }
    private async Task AddDeviceHeaders(int devicetId, DeviceType deviceType)
    {
        var temps = await _context
            .Templates
            .Include(x=>x.TemplatePositions)
            .Where(x => x.DeviceType == deviceType)
            .ToListAsync();
        var headers = temps.Select(x => x.TemplatePositions).ToList();

        foreach (var header in headers)
        {
            var deviceHeader = new DeviceHeader
            {
                DeviceId = devicetId,
                Name = header.Select(x => x.Name).ToString(),
                Description = header.Select(x => x.Description).ToString(),
                Order = header.Select(x => x.Order).FirstOrDefault()
            };
            _context.DeviceHeaders.Add(deviceHeader);
        }
        await _context.SaveChangesAsync();
    }
}
