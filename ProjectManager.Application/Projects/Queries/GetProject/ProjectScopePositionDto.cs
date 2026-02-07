namespace ProjectManager.Application.Projects.Queries.GetProject;

public class ProjectScopePositionDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public bool NotApplicable { get; set; }
    public DateTime? CompletionDate { get; set; }
}