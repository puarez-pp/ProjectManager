using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Queries.GetProject;
public class ProjectDto
{
    public int Id { get; set; }
    public string User { get; set; }
    public string UserUpdate { get; set; }
    public string UserPM { get; set; }
    public string Client { get; set; }
    public string ProjectType { get; set; }
    public ProjectStatus ProjectStatus { get; set; }
    public string Number { get; set; } 
    public string Name { get; set; }
    public string Comment { get; set; }
    public string Sharepoint { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EditDate { get; set; }
    public DateTime? FinishedDate { get; set; }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   