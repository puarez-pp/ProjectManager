using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Application.Plants.Queries.GetPlant;

namespace ProjectManager.Application.Devices.Queries.GetAlarms;

public class GetAlarmsVm
{
    public PlantDto Plant { get; set; }
    public DeviceDto Device { get; set; }
    public List<AlarmDto> Alarms { get; set; }
}
