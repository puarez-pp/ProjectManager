using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class TodoNotificationLog
{
    public int Id { get; set; }
    public int TodoId { get; set; }
    public Todo Todo { get; set; }
    public DateTime CreatedAt { get; set; }
    public NotificationChannel Channel { get; set; }
}
