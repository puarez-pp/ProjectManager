using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Queries.GetPosition;

public class PositionDto
{
    public int Id { get; set; }
    public DivisionPositionType Name { get; set; }
    public string Comment { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? PerformedData { get; set; }
    public string SubContractor { get; set; }
    public List<PositionPost> PositionPosts { get; set; } = new List<PositionPost>();
}
