namespace ProjectManager.Domain.Entities;

public class Activity
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int Est { get; set; }
    public int Lst { get; set; }
    public int Order { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
    public ICollection<Predecessor> Predecessors { get; set; } = new HashSet<Predecessor>();

}
