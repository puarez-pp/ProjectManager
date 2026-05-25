using MediatR;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Telemetries.Commands;

public class AddAlarmCommand:IRequest<Guid>
{
    public AlarmType AlarmType { get; set; }
    public int DeviceId { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Name { get; set; }
}
