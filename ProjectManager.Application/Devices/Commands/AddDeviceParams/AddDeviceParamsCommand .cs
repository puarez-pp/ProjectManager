using MediatR;
using ProjectManager.Application.Devices.Queries.GetDevice;

namespace ProjectManager.Application.Devices.Commands.AddDeviceParams;

public class AddDeviceParamsCommand : IRequest
{
    public int DeviceId { get; set; }
    public List<DeviceParamDto> DeviceParams { get; set; }
}
