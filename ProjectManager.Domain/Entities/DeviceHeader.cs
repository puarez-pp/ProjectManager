namespace ProjectManager.Domain.Entities;

public class DeviceHeader
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public bool Used { get; set; }
    public Device Device { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
