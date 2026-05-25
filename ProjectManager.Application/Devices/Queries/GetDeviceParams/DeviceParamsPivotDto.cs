namespace ProjectManager.Application.Devices.Queries.GetDeviceParams;

public class DeviceParamsPivotDto
{
    public int DeviceId { get; set; }
    public List<string> Columns { get; set; } = new();
    public List<PivotRowDto> Rows { get; set; } = new();
}
