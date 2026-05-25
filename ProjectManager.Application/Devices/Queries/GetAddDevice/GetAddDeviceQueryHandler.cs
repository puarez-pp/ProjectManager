using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.AddDevice;
using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Application.Plants.Queries.GetPlant;

namespace ProjectManager.Application.Devices.Queries.GetAddDevice;

public class GetAddDeviceQueryHandler : IRequestHandler<GetAddDeviceQuery, AddDeviceVm>
{
    private readonly IApplicationDbContext _context;

    public GetAddDeviceQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<AddDeviceVm> Handle(GetAddDeviceQuery request, CancellationToken cancellationToken)
    {
        var plant = await _context
            .Plants
            .Include(x => x.Devices)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        var vm = new AddDeviceVm
        {
            Plant = new PlantDto 
            { 
                Id = plant.Id, 
                Name = plant.Name, 
                Location = plant.Location, 
                CreatedAt = plant.CreatedAt,
                UserId = plant.UserId,
                Devices = plant.Devices.Select(d => new DeviceDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    DeviceType = d.DeviceType,
                    CreatedAt = d.CreatedAt
                }).ToList()
            },
            Device = new AddDeviceCommand {PlantId = plant.Id}
        };

        return vm;
    }
}
