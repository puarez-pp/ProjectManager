namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class DeviceParamDto
{
    public Guid Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Name { get; set; }
    public float Value { get; set; }
}
