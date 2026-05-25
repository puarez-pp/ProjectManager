using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Devices.Queries.GetDeviceParams;

public class DeviceSelectedParamsDto
{
    public int Id { get; set; }
    public DeviceType DeviceType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DeviceParamsPivotDto DeviceParamsPivot { get; set; } = new();
}
