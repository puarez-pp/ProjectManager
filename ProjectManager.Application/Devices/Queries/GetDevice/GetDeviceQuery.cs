using MediatR;

namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class GetDeviceQuery: IRequest<DeviceDto>
{
    public int Id { get; set; }
}
