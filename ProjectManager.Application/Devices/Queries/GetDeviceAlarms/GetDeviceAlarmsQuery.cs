using MediatR;
using ProjectManager.Application.Devices.Queries.GetDevice;

namespace ProjectManager.Application.Devices.Queries.GetDeviceAlarms;

public class GetDeviceAlarmsQuery : IRequest<IEnumerable<AlarmDto>>
{
    public int Id { get; set; }
}
