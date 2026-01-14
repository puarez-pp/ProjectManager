using MediatR;

namespace ProjectManager.Application.Devices.Queries.GetAddDevice;

public class GetAddDeviceQuery:IRequest<AddDeviceVm>
{
    public int Id { get; set; }
}
