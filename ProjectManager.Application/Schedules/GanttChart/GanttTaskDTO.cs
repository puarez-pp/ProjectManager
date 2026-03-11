namespace ProjectManager.Application.Schedules.GanttChart;

public class GanttTaskDTO
{
    public int TaskId { get; set; }
    public string Name { get; set; }

    // Daty do wykresu
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    // CPM
    public TimeSpan ES { get; set; }
    public TimeSpan EF { get; set; }
    public TimeSpan LS { get; set; }
    public TimeSpan LF { get; set; }
    public TimeSpan Slack { get; set; }

    public bool IsCritical { get; set; }

    public List<int> SuccessorIds { get; set; } = new();
}