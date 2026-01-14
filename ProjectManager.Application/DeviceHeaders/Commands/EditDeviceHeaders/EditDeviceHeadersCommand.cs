using MediatR;
using ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;

namespace ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeaders;

public class EditDeviceHeadersCommand: IRequest
{
    public List<DeviceHeaderDto> Headers { get; set; }
}
