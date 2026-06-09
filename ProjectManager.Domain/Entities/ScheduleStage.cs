namespace ProjectManager.Domain.Entities;

public class ScheduleStage
{
    public int Id { get; set; }

    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }


    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public ICollection<ScheduleTask> Tasks { get; set; } = new HashSet<ScheduleTask>();
}


