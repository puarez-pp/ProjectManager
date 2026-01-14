using MediatR;

namespace ProjectManager.Application.Devices.Queries.GetEditDevice;

public class GetEditDeviceQuery:IRequest<EditDeviceVm>
{
    public int Id { get; set; }
}
