using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Projects.Queries.GetProject;

public class PositionPostDto
{
    public int Id { get; set; }
    public int PositionId { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; }
    public UserDto User { get; set; }
}
