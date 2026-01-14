using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Extension;
using ProjectManager.Application.Plants.Extension;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders
{
    public class GetDeviceHeadersQueryHandler : IRequestHandler<GetDeviceHeadersQuery, GetDeviceHeadersVm>
    {
        private readonly IApplicationDbContext _context;

        public GetDeviceHeadersQueryHandler(
            IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GetDeviceHeadersVm> Handle(GetDeviceHeadersQuery request, CancellationToken cancellationToken)
        {
            var device = await _context
                .Devices
                .AsNoTracking()
                .Include(x => x.DeviceHeaders)
                .Where(x => x.Id == request.Id)
                .ToListAsync();

            var headers = new GetDeviceHeadersVm
            {
                Plant = device.FirstOrDefault()?.Plant.ToPlantDto(),
                Device = device.FirstOrDefault()?.ToDeviceDto(),
                Headers = device.FirstOrDefault()?.DeviceHeaders.Select(x => x.ToDeviceHeaderDto()).ToList()
            };
            return headers;
        }
    }
}
