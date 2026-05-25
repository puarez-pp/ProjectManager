using MediatR;
using ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetEditDeviceHeader;

public class GetEditDeviceHeaderQuery:IRequest<EditDeviceHeaderCommand>
{
    public int Id { get; set; }
}
