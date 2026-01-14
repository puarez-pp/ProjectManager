using ProjectManager.Application.Devices.Queries.GetDevice;

namespace ProjectManager.Application.Plants.Queries.GetPlant;

public class GetPlantVm
{
    public PlantDto Plant { get; set; }
    public List<DeviceDto> Devices { get; set; } = new List<DeviceDto>();
}