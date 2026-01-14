namespace ProjectManager.Application.Common.Interfaces;

public interface IUserNotification
{
    Task SendNotificationAsync(string userId, string message);
}
