using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Devices.Queries.GetDevice;

public class AlarmDto
{
    public Guid Id { get; set; }
    public AlarmType AlarmType { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Name { get; set; }
}
