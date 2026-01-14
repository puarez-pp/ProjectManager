using ProjectManager.Application.Devices.Commands.AddDevice;
using ProjectManager.Application.Plants.Queries.GetPlant;

namespace ProjectManager.Application.Devices.Queries.GetAddDevice;

public class AddDeviceVm
{
    public PlantDto Plant { get; set; }
    public AddDeviceCommand Device { get; set; }
}
