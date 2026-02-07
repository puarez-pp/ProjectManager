using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class ProjectScopeTemplate
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ProjectType ProjectType { get; set; }
    public int Order { get; set; }
    public ICollection<ProjectScopePositionTemplate> ProjectScopePositions { get; set; } = new HashSet<ProjectScopePositionTemplate>();
}
