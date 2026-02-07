using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class TodoDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string UserFrom { get; set; }
    public string UserTo { get; set; }
}
