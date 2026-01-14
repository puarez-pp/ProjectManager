using MediatR;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetEditDeviceHeader;

public class GetEditDeviceHeaderQuery:IRequest<GetEditDeviceHeaderVm>
{
    public int Id { get; set; }
}
