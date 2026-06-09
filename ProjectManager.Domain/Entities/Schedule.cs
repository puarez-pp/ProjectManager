namespace ProjectManager.Domain.Entities;

public class Schedule
{
    public int Id { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public string Name { get; set; }
    public string Comment { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime EditAt { get; set; }

    public ICollection<ScheduleStage> Stages { get; set; } = new HashSet<ScheduleStage>();
}


