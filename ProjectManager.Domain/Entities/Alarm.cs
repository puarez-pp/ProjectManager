using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Alarm
{
    public int Id { get; set; }
    public AlarmType AlarmType { get; set; }
    public int DeviceId { get; set; }
    public Device Device { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Description { get; set; }
}
