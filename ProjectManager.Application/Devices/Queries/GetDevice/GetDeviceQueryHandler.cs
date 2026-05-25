using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Extension;
using ProjectManager.Domain.Enums;
using System.Linq.Dynamic.Core;

namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class GetDeviceQueryHandler : IRequestHandler<GetDeviceQuery, DeviceDto>
{
    private readonly IApplicationDbContext _context;

    public GetDeviceQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<DeviceDto> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
    {
        var device = await _context
            .Devices
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        return device.ToDeviceDto();
    }
}
