using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class DeviceTemplate
{
    public int Id { get; set; }
    public DeviceType DeviceType { get; set; }
    public ICollection<DeviceTemplatePosition> TemplatePositions { get; set; } = new HashSet<DeviceTemplatePosition>();
}
