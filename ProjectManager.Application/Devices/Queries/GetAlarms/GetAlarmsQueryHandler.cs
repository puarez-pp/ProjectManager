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
            .Include(x => x.LogAlarms)
            .FirstOrDefaultAsync(x => x.Id == request.Id);
 
        var alarms = new GetAlarmsVm
        {
            Plant = device.Plant.ToPlantDto(),
            Device = device.ToDeviceDto(),
            Alarms = device.LogAlarms.Select(x=>x.ToAlarmDto()).ToList(),
        };
        return alarms;
    }
}
