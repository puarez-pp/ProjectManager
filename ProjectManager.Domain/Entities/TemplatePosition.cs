namespace ProjectManager.Domain.Entities;

public class TemplatePosition
{
    public int Id { get; set; }
    public int TemplateId { get; set; }
    public Template Template { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}
