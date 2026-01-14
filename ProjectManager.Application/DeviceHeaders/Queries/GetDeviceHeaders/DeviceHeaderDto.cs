namespace ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;

public class DeviceHeaderDto
{
    public int Id { get; set; }
    public bool Used { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
