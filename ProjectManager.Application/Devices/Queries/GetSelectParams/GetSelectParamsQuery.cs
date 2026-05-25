using MediatR;

namespace ProjectManager.Application.Devices.Queries.GetSelectParams;

public class GetSelectParamsQuery : IRequest<DeviceParamNamesDto>
{
    public int Id { get; set; }
}
