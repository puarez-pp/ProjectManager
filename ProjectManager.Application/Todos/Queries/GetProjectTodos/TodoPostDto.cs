using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetProjectTodos;

public class TodoPostDto
{
    public int Id { get; set; }
    public string Body { get; set; }
    public UserDto User { get; set; }
    public DateTime CreatedAt { get; set; }
}