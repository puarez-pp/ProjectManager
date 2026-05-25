using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Queries.GetDevice;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders
{
    public class GetDeviceHeadersQueryHandler : IRequestHandler<GetDeviceHeadersQuery, DeviceDto>
    {
        private readonly IApplicationDbContext _context;

        public GetDeviceHeadersQueryHandler(
            IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<DeviceDto> Handle(GetDeviceHeadersQuery request, CancellationToken cancellationToken)
        {
            var device = await _context
                .Devices
                .AsNoTracking()
                .Where(x=>x.Id == request.Id)
                .Select(x=> new DeviceDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    DeviceType = x.DeviceType,
                    IsConfigured = x.IsConfigured,
                    DeviceHeaders = x.DeviceHeaders.OrderBy(y=>y.Order)
                    .Select(y=> new DeviceHeaderDto
                    {
                        Id = y.Id, 
                        Name = y.Name,
                        Description = y.Description,
                        Order = y.Order
                    }).ToList()
                })
                .FirstOrDefaultAsync();
            return device;
        }
    }
}
