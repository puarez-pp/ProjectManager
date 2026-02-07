using ProjectManager.Application.Users.Queries.GetUser;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Queries.GetProject;
public class ProjectDto
{
    public int Id { get; set; }
    public UserDto User { get; set; }
    public UserDto UserUpd { get; set; }
    public UserDto ProjectManager { get; set; }
    public UserDto DesignEng { get; set; }
    public UserDto ElectricEng { get; set; }
    public string Client { get; set; }
    public string ProjectType { get; set; }
    public ProjectStatus ProjectStatus { get; set; }
    public string Number { get; set; } 
    public string Name { get; set; }
    public string Comment { get; set; }
    public string Sharepoint { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime EditdAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public List<ProjectScopeDto> Scopes { get; set; }
}
