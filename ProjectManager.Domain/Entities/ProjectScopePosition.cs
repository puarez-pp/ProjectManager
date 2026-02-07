using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class ProjectScopePosition
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public bool NotApplicable { get; set; }
    public DateTime? CompletionDate { get; set; }
    public int ProjectScopeId { get; set; }
    public ProjectScope ProjectScope { get; set; }
    public int Order { get; set; }
    public ICollection<PositionPost> PositionPosts { get; set; } = new HashSet<PositionPost>();
}
