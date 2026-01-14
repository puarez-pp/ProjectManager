using MediatR;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;

public class GetDeviceHeadersQuery:IRequest<GetDeviceHeadersVm>
{
    public int Id { get; set; }
}
