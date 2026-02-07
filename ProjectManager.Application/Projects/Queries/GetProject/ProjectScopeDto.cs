namespace ProjectManager.Application.Projects.Queries.GetProject;

public class ProjectScopeDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public List<ProjectScopePositionDto> Positions { get; set; }
}
