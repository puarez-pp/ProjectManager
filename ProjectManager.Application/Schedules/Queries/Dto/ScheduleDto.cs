namespace ProjectManager.Application.Schedules.Queries.Dto;

public class ScheduleDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime EditAt { get; set; }
    public int StagesCount { get; set; }
    public int TasksCount { get; set; }
}
