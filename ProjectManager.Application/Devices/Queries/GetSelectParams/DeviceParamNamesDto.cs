using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Devices.Queries.GetSelectParams;

public class DeviceParamNamesDto
{
    public int Id { get; set; }
    public DeviceType DeviceType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<ParamNamesDto> ParamNames { get; set; } = new();
}
