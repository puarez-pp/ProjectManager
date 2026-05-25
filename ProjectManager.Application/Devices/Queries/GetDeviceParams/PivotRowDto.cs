namespace ProjectManager.Application.Devices.Queries.GetDeviceParams;

public class PivotRowDto
{
    public DateTime TimeStamp { get; set; }
    public Dictionary<string, float?> Values { get; set; } = new();
}