using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Devices.Queries.GetAlarms;

public class AlarmDto
{
    public long Id { get; set; }
    public AlarmType AlarmType { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Description { get; set; }
}
