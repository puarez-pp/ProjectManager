using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.EditDevice;
using ProjectManager.Application.Plants.Extension;

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
            .FirstOrDefaultAsync(x => x.Devices.Any(x => x.Id == request.Id));

        var vm = new EditDeviceVm
        {
            Plant = plant.ToPlantDto(),
            Device = new EditDeviceCommand { Id = request.Id }
        };

        return vm;
    }
}
