namespace ProjectManager.Application.Projects.Queries.GetCommnents;

public class PostReplyDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserId { get; set; }
    public string User { get; set; }
}