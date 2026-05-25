using MediatR;
using ProjectManager.Application.Devices.Queries.GetDevice;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;

public class GetDeviceHeadersQuery:IRequest<DeviceDto>
{
    public int Id { get; set; }
}
