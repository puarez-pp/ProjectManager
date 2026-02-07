using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

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
        var template = await _context
            .DeviceTemplates
            .AsNoTracking ()
            .Include(t => t.TemplatePositions)
            .FirstOrDefaultAsync(t => t.DeviceType == request.DeviceType);

        if (template == null)
            throw new Exception("Nie znaleionu właściwego szablonu");

        var device = new Device
        {
            PlantId = request.PlantId,
            Name = request.Name,
            Description = request.Description,
            DeviceType = request.DeviceType,
            UserId = _userService.UserId,
            CreatedAt = _timeService.Now
        };

        foreach (var pos in template.TemplatePositions.OrderBy(p => p.Order)) 
        { 
            device.DeviceHeaders.Add(new DeviceHeader 
            { 
                Name = pos.Name, 
                Description = pos.Description, 
                Order = pos.Order 
            }); 
        }
        _context.Devices.Add(device); 
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
