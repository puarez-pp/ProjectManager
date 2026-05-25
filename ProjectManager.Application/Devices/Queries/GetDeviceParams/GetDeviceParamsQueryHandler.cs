using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Devices.Queries.GetDeviceParams;

public class GetDeviceParamsQueryHandler:IRequestHandler<GetDeviceParamsQuery, DeviceSelectedParamsDto>
{
    private readonly IApplicationDbContext _context;

    public GetDeviceParamsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DeviceSelectedParamsDto> Handle(GetDeviceParamsQuery request, CancellationToken cancellationToken)
    {
        var device = await _context
            .Devices
            .Where(d => d.Id == request.Id)
            .Select(d => new 
            {
                d.Id,
                d.Name,
                d.Description,
                d.DeviceType
            })
            .FirstOrDefaultAsync();

        var query = _context.DeviceParams
        .Where(p => p.DeviceId == request.Id);

        if (request.Start != default)
            query = query.Where(p => p.TimeStamp >= request.Start);

        if (request.End.HasValue)
            query = query.Where(p => p.TimeStamp <= request.End.Value);

        if (request.ParamNames != null && request.ParamNames.Any())
            query = query.Where(p => request.ParamNames.Contains(p.Name));

        var data = await query
        .OrderByDescending(p => p.TimeStamp)
        .ToListAsync(cancellationToken);

        // Lista unikalnych nazw parametrów (kolumny)
        var columns = data
            .Select(p => p.Name)
            .Distinct()
            .OrderBy(p=>p)
            .ToList();

        // Lista unikalnych timestampów (wiersze)
        var timestamps = data
            .Select(p => p.TimeStamp)
            .Distinct()
            .ToList();

        var rows = timestamps
        .Select(ts => new PivotRowDto
        {
            TimeStamp = ts,
            Values = columns.ToDictionary(
                col => col,
                col => data
                    .FirstOrDefault(p => p.TimeStamp == ts && p.Name == col)
                    ?.Value
            )
        })
        .ToList();

        return new DeviceSelectedParamsDto
        {
            Id = device.Id,
            Name = device.Name,
            Description = device.Description,
            DeviceType = device.DeviceType,
            DeviceParamsPivot = new DeviceParamsPivotDto
            {
                Columns = columns,
                Rows = rows
            }
        };

    }


}
