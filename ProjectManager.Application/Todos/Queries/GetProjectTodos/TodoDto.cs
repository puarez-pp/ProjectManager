using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class TodoDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int PostsNumber { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public UserDto UserFrom { get; set; }
    public UserDto UserTo { get; set; }
}
