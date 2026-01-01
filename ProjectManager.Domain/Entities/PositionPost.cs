namespace ProjectManager.Domain.Entities;
public class PositionPost
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public int PositionId { get; set; }
    public DivisionPosition Position { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
