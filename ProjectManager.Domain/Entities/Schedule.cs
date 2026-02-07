namespace ProjectManager.Domain.Entities;

public class Schedule
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string UserID { get; set; }
    public ApplicationUser User { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();
    public ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();
}
