using ProjectManager.Application.Devices.Commands.EditDevice;
using ProjectManager.Application.Plants.Queries.GetPlant;

namespace ProjectManager.Application.Devices.Queries.GetEditDevice;

public class EditDeviceVm
{
    public PlantDto Plant { get; set; }
    public EditDeviceCommand Device { get; set; }
}
