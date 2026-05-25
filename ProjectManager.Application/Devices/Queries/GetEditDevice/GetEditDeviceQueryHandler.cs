using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.EditDevice;
using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Application.Plants.Queries.GetPlant;

namespace ProjectManager.Application.Devices.Queries.GetEditDevice;

public class GetEditDeviceQueryHandler : IRequestHandler<GetEditDeviceQuery, EditDeviceVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditDeviceQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditDeviceVm> Handle(GetEditDeviceQuery request, CancellationToken cancellationToken)
    {
        var plant = await _context
            .Plants
            .AsNoTracking()
            .Where(x=>x.Devices.Any(y=>y.Id == request.Id))
            .Select(x=>new PlantDto
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
                CreatedAt = x.CreatedAt,
                UserId = x.UserId,
                Devices = x.Devices
                .OrderBy(d => d.Name)
                .Select(d => new DeviceDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    DeviceType = d.DeviceType,
                    CreatedAt = d.CreatedAt,
                    IsConfigured = d.IsConfigured,
                }).ToList()
            }).SingleOrDefaultAsync();

        var device = plant.Devices.FirstOrDefault(x=>x.Id == request.Id);

        return new EditDeviceVm
        {
            Plant = plant,
            Device = new EditDeviceCommand
            {
                Id= request.Id,
                Name = device.Name,
                Description = device.Description,
                DeviceType = device.DeviceType,
            }
        };
    }
}
