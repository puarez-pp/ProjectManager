using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class WorkScopeTemplate
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ProjectType ProjectType { get; set; }
    public int Order { get; set; }
    public ICollection<WorkScopePositionTemplate> WorkScopePositions { get; set; } = new HashSet<WorkScopePositionTemplate>();
}
