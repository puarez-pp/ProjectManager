namespace ProjectManager.Application.Posts.Queries.GetCommnents;

public class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserId { get; set; }
    public string User { get; set; }
    public List<PostReplyDto> Replies { get; set; } = new List<PostReplyDto>();
}