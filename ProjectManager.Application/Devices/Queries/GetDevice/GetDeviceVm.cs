using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Plants.Queries.GetPlant;

namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class GetDeviceVm
{
    public PlantDto Plant { get; set; }
    public DeviceDto Device { get; set; }
    public IEnumerable<IDeviceParam> Params { get; set; }
}
