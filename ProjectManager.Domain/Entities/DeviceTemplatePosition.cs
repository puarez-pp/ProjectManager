namespace ProjectManager.Domain.Entities;

public class DeviceTemplatePosition
{
    public int Id { get; set; }
    public int TemplateId { get; set; }
    public DeviceTemplate Template { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
