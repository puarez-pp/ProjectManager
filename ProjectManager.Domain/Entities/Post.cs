namespace ProjectManager.Domain.Entities;

public  class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public ICollection<PostReply> PostReplies { get; set; } = new HashSet<PostReply>();
}
