namespace ProjectManager.Application.Schedules.Dto;

public class CriticalPathTaskDto
{
    public int TaskId { get; set; }
    public string Name { get; set; }

    // Daty planowane 
    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    // CPM – Early / Late
    public TimeSpan ES { get; set; }
    public TimeSpan EF { get; set; }
    public TimeSpan LS { get; set; }
    public TimeSpan LF { get; set; }
    public TimeSpan Slack { get; set; }

    public bool IsCritical => Slack == TimeSpan.Zero;

    // Do wizualizacji zależności
    public List<int> PredecessorIds { get; set; } = new();
    public List<int> SuccessorIds { get; set; } = new();
}
