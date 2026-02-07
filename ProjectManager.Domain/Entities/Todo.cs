using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FinishDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string UserFromId { get; set; }
    public ApplicationUser UserFrom { get; set; }
    public string UserToId { get; set; }
    public ApplicationUser UserTo { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; } 
    public ICollection<TodoPost> TodoPosts { get; set; } = new HashSet<TodoPost>();
    public ICollection<TodoToUser> TodoToUsers { get; set; } = new HashSet<TodoToUser>();
}
