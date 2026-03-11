 

using Microsoft.AspNetCore.Identity;

namespace ProjectManager.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime RegisterDateTime { get; set; }

    public Employee Employee { get; set; }

    public ICollection<Project> ProjectsCreator { get; set; } = new HashSet<Project>();
    public ICollection<Project> ProjectsUpdator { get; set; } = new HashSet<Project>();
    public ICollection<Project> ProjectsPM { get; set; } = new HashSet<Project>();
    public ICollection<Project> DesignEng { get; set; } = new HashSet<Project>();
    public ICollection<Project> ElectricEng { get; set; } = new HashSet<Project>();
    public ICollection<ProjectScope> ProjectScopes { get; set; } = new HashSet<ProjectScope>();
    public ICollection<EmployeeEvent> EmployeeEvents { get; set; } = new HashSet<EmployeeEvent>();
    public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    public ICollection<PostReply> PostReplies { get; set; } = new HashSet<PostReply>();
    public ICollection<Todo> Todos { get; set; } = new HashSet<Todo>();
    public ICollection<TodoPost> TodoPosts { get; set; } = new HashSet<TodoPost>();
    public ICollection<PositionPost> PositionPosts { get; set; } = new HashSet<PositionPost>();
    public ICollection<ToolRent> Rents { get; set; } = new HashSet<ToolRent>();
    public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
    public ICollection<ScheduleTask> ScheduleTasks { get; set; } = new HashSet<ScheduleTask>();
    public ICollection<Settlement> Settlements { get; set; } = new HashSet<Settlement>();
}
