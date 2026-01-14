using MediatR;

namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class GetDeviceQuery: IRequest<GetDeviceVm>
{
    public int Id { get; set; }
}
