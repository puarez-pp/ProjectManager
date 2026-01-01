namespace ProjectManager.Domain.Entities;

public class Predecessor
{
    public int Id { get; set; }
    public int ActivityId { get; set; }
    public Activity Activity { get; set; }
}
