namespace ProjectManager.Domain.Entities;

public class ProjectScopePositionTemplate
{
    public int Id { get; set; }
    public int ProjectScopeTemplateId { get; set; }
    public ProjectScopeTemplate ProjectScopeTemplate { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}