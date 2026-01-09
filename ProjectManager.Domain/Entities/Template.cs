using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Template
{
    public int Id { get; set; }
    public DeviceType DeviceType { get; set; }
    public ICollection<TemplatePosition> TemplatePositions { get; set; } = new HashSet<TemplatePosition>();
}
