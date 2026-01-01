namespace ProjectManager.Domain.Entities;

public class TodoToUser
{
    public int Id { get; set; }
    public int TodoId { get; set; }
    public Todo Todo { get; set; }
    public string UserID { get; set; }
    public ApplicationUser User { get; set; }
}