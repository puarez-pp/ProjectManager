using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Extension;
using ProjectManager.Application.Plants.Extension;
using ProjectManager.Domain.Enums;
using System.Linq.Dynamic.Core;

namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, GetDeviceVm>
{
    private readonly IApplicationDbContext _context;

    public GetDeviceQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetDeviceVm> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
    {
        var device = await _context
            .Devices
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        IEnumerable <IDeviceParam> deviceParams = new List<IDeviceParam>();
        var vm = new GetDeviceVm();

        if (device != null) 
        {
            switch (device.DeviceType)
            {
                case DeviceType.Engine:
                    deviceParams = await _context
                        .Engines
                        .AsNoTracking()
                        .Where(x => x.DeviceId == device.Id)
                        .Select(x => x.ToEngineDto()).ToListAsync();
                    break;
                case DeviceType.GasCounter:
                    deviceParams = await _context
                        .GasCounters
                        .AsNoTracking()
                        .Where(x => x.DeviceId == device.Id)
                        .Select(x => x.ToGasCounterDto()).ToListAsync();
                    break;
                case DeviceType.HeatCounter:
                    deviceParams = await _context
                        .HeatCounters
                        .AsNoTracking()
                        .Where(x => x.DeviceId == device.Id)
                        .Select(x => x.ToHeatCounterDto()).ToListAsync();
                    break;
                case DeviceType.ElectricCounter:
                    deviceParams = await _context
                        .ElectricCounters
                        .AsNoTracking()
                        .Where(x => x.DeviceId == device.Id)
                        .Select(x => x.ToElectricCounterDto()).ToListAsync();
                    break;
                case DeviceType.Other:
                    deviceParams = await _context
                        .OtherCounters
                        .AsNoTracking()
                        .Where(x => x.DeviceId == device.Id)
                        .Select(x => x.ToOtherCounterDto()).ToListAsync();
                    break;
                default:
                    break;
            }
        }
        vm.Plant = device.Plant.ToPlantDto();
        vm.Device = device.ToDeviceDto();
        vm.Params = deviceParams;
        return vm;
    }
}
