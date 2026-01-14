using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Application.Plants.Queries.GetPlant;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;

public class GetDeviceHeadersVm
{
    public PlantDto Plant { get; set; }
    public DeviceDto Device { get; set; }
    public List<DeviceHeaderDto> Headers { get; set; }
}
