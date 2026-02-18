using Microsoft.EntityFrameworkCore;

namespace minAPI;

public record TodoItem(int Id, string Title, bool IsDone);

public class ToDoDb:DbContext
{
    public ToDoDb(DbContextOptions<ToDoDb> options) : base(options)
    {
    }
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
}