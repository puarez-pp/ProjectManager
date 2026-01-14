using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Queries.GetPosition;

public class PositionPostDto
{
    public int Id { get; set; }
    public int PositionId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserId { get; set; }
    public string User { get; set; }
}
