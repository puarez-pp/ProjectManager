namespace ProjectManager.Application.Common.Interfaces;

public interface ITodoNotificationService
{
    Task SendOverdueTodoNotificationsAsync();
}
