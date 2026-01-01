namespace ProjectManager.Domain.Entities;

public class PostReply
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }
}
