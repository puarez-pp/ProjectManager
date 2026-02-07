using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class ProjectScope
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public int Order { get; set; }
    public ICollection<ProjectScopePosition> Positions { get; set; } = new HashSet<ProjectScopePosition>();
}

