using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string UserID { get; set; }
    public ApplicationUser User { get; set; }
    public string UserPMId { get; set; }
    public ApplicationUser UserPM { get; set; }
    public string DesignEngId { get; set; }
    public ApplicationUser DesignEng { get; set; }
    public string ElectricEngId { get; set; }
    public ApplicationUser ElectricEng { get; set; }
    public string UserUpdatorId { get; set; }
    public ApplicationUser UserUpdator { get; set; }
    public  ProjectType ProjectType { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public ProjectStatus Status { get; set; }
    public string Sharepoint { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime EditAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public int ClientId { get; set; }
    public Client Client{ get; set; }
    public bool IsCompleted { get; set; }
    public Settlement Settlement { get; set; }
    public ICollection<ProjectScope> ProjectScopes { get; set; } = new HashSet<ProjectScope>();
    public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    public ICollection<Todo> Todos { get; set; } = new HashSet<Todo>();
    public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();

}
