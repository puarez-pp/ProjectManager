using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.AddDevice;
using ProjectManager.Application.Plants.Extension;

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
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        var vm = new AddDeviceVm
        {
            Plant = plant.ToPlantDto(),
            Device = new AddDeviceCommand {PlantId = request.Id}
        };

        return vm;
    }
}
