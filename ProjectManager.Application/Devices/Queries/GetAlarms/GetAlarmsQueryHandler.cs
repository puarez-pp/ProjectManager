using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Extension;
using ProjectManager.Application.Plants.Extension;

namespace ProjectManager.Application.Devices.Queries.GetAlarms;

public class GetAlarmsQueryHandler : IRequestHandler<GetAlarmsQuery, GetAlarmsVm>
{
    private readonly IApplicationDbContext _context;

    public GetAlarmsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetAlarmsVm> Handle(GetAlarmsQuery request, CancellationToken cancellationToken)
    {
        var device = await _context
            .Devices
            .AsNoTracking()
            .Include(x => x.Alarms)
            .Where(x => x.Id == request.Id)
            .ToListAsync();

        var alarms = new GetAlarmsVm
        {
            Plant = device.FirstOrDefault()?.Plant.ToPlantDto(),
            Device = device.FirstOrDefault()?.ToDeviceDto(),
            Alarms = device.FirstOrDefault()?.Alarms.Select(x => x.ToAlarmDto()).ToList()
        };
        return alarms;
    }
}
