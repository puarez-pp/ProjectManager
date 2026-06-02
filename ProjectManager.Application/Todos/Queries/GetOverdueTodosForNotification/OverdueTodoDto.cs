namespace ProjectManager.Application.Todos.Queries.GetOverdueTodosForNotification;

public class OverdueTodoDto
{
    public int Id { get; set; }
    public string UserToId { get; set; }
    public string Title { get; set; }
    public DateTime? FinishDate { get; set; }
    public string UserToEmail { get; set; }
}
