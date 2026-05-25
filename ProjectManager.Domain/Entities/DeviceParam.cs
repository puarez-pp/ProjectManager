namespace ProjectManager.Domain.Entities;

public class DeviceParam
{
    public Guid Id { get; set; }
    public int DeviceId { get; set; }
    public Device Device { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Name { get; set; }
    public float Value { get; set; }
}
