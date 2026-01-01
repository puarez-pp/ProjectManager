using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Division
{
    public int Id { get; set; }
    public DivisionType DivisionType { get; set; }
    public string Comment { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public ICollection<DivisionPosition> Positions { get; set; } = new HashSet<DivisionPosition>();
}

