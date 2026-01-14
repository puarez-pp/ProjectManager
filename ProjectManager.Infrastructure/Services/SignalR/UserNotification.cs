using Microsoft.AspNetCore.SignalR;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Infrastructure.Services.SignalR;

public class UserNotification : IUserNotification
{
    private readonly IHubContext<NotificationUserHub> _hubContext;
    private readonly IUserConnectionManager _userConnectionManager;

    public UserNotification(
        IHubContext<NotificationUserHub> hubContext,
        IUserConnectionManager userConnectionManager)
    {
        _hubContext = hubContext;
        _userConnectionManager = userConnectionManager;
    }
    public async Task SendNotificationAsync(string userId, string message)
    {
        
        var connections = _userConnectionManager.GetUserConnections(userId);
        if (connections == null || !connections.Any())
            return;
        {
            foreach (var connectionId in connections)
            {
                await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveNotification", message);
            }
        }
    }
}
