using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;
using ProjectManager.Application.Devices.Extension;
using ProjectManager.Application.Plants.Extension;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetEditDeviceHeader;

public class GetEditDeviceHeaderQueryHandler : IRequestHandler<GetEditDeviceHeaderQuery, GetEditDeviceHeaderVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditDeviceHeaderQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetEditDeviceHeaderVm> Handle(GetEditDeviceHeaderQuery request, CancellationToken cancellationToken)
    {
        var header = await _context
            .DeviceHeaders
            .Where(x => x.Id == request.Id)
            .Select(x => new GetEditDeviceHeaderVm
            {
                Plant = x.Device.Plant.ToPlantDto(),
                Device = x.Device.ToDeviceDto(),
                Header = new EditDeviceHeaderCommand
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Used = x.Used
                }
            })
            .FirstOrDefaultAsync();  
        return header;
    }
}
