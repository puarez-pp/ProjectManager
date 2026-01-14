using ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;
using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Application.Plants.Queries.GetPlant;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetEditDeviceHeader;

public class GetEditDeviceHeaderVm
{
    public PlantDto Plant { get; set; }
    public DeviceDto Device { get; set; }
    public EditDeviceHeaderCommand Header { get; set; }
}
