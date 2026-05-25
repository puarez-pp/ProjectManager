using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class GetDeviceVm
{
    public DeviceDto Device { get; set; }
    public IEnumerable<IDeviceParam> Params { get; set; }
    public IEnumerable<AlarmDto> Alarms { get; set; }
}
