using MediatR;

namespace ProjectManager.Application.Devices.Queries.GetDeviceParams;

public class GetDeviceParamsQuery : IRequest<DeviceSelectedParamsDto>
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
    public List<string> ParamNames { get; set; }
}
