namespace ProjectManager.Application.Posts.Queries.GetCommnents;

public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public string User { get; set; }
    public List<PostReplyDto> Replies { get; set; } = new List<PostReplyDto>();
}