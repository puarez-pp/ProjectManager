using MediatR;

namespace ProjectManager.Application.Devices.Queries.GetAlarms;

public class GetAlarmsQuery : IRequest<GetAlarmsVm>
{
    public int Id { get; set; }
}
