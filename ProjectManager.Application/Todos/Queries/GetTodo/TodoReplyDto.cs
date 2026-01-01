using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Todos.Queries.GetTodo;

public class TodoReplyDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public string UserId { get; set; }
    public string User { get; set; }
    public int TodoId { get; set; }
    public DateTime CreatedDate { get; set; }
}
