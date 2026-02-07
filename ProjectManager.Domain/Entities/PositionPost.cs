namespace ProjectManager.Domain.Entities;
public class PositionPost
{
    public int Id { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public int PositionId { get; set; }
    public ProjectScopePosition Position { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
