 

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
    public ICollection<Division> Divisions { get; set; } = new HashSet<Division>();
    public ICollection<EmployeeEvent> EmployeeEvents { get; set; } = new HashSet<EmployeeEvent>();
    public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    public ICollection<PostReply> PostReplies { get; set; } = new HashSet<PostReply>();
    public ICollection<Todo> TodosFrom { get; set; } = new HashSet<Todo>();
    public ICollection<Todo> TodosTo { get; set; } = new HashSet<Todo>();
    public ICollection<TodoPost> TodoPosts { get; set; } = new HashSet<TodoPost>();
    public ICollection<TodoPost> TodoPostsRedirect { get; set; } = new HashSet<TodoPost>();
    public ICollection<PositionPost> PositionPosts { get; set; } = new HashSet<PositionPost>();
    public ICollection<ToolRental> ToolRentals { get; set; } = new HashSet<ToolRental>();
    public ICollection<TodoToUser> TodoToUsers { get; set; } = new HashSet<TodoToUser>();
    public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
    public ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();
    public ICollection<Plant> Plants { get; set; } = new HashSet<Plant>();
    public ICollection<Device> Devices { get; set; } = new HashSet<Device>();
}
