namespace ProjectManager.Domain.Entities;

public class PostReply
{
    public int Id { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }
}
