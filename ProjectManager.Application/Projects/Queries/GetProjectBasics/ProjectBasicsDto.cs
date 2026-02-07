using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Queries.GetProjectBasics;

public class ProjectBasicsDto
{
    public int Id { get; set; }
    public string ProjectType { get; set; }
    public ProjectStatus ProjectStatus { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public int ClientId { get; set; }
    public string Client { get; set; }
    public string Sharepoint { get; set; }
    public DateTime EditAt { get; set; }
}
