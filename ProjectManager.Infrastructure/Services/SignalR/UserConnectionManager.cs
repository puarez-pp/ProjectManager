using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Infrastructure.Services.SignalR;

public class UserConnectionManager : IUserConnectionManager
{
    private static string _userConnectionMapLocker = string.Empty;
    private static Dictionary<string, List<string>> _userConnectionMap = new();

    public void KeepUserConnection(string userId, string connectionId)
    {
        lock (_userConnectionMapLocker)
        {
            if (!_userConnectionMap.ContainsKey(userId))
            {
                _userConnectionMap[userId] = new List<string>();
            }
            _userConnectionMap[userId].Add(connectionId);
        }
    }

    public void RemoveUserConnection(string connectionId)
    {
        lock(_userConnectionMapLocker)
        {
            foreach (var userId in _userConnectionMap.Keys)
            {
                if (_userConnectionMap[userId].Contains(connectionId))
                {
                    _userConnectionMap[userId].Remove(connectionId);
                    break;
                }
            }
        }   
    }

    public List<string> GetUserConnections(string userId)
    {
        var connections = new List<string>();
        try
        {
            lock (_userConnectionMapLocker)
            {
                if (_userConnectionMap.ContainsKey(userId))
                {
                    connections = _userConnectionMap[userId];
                }
            }
        }
        catch (Exception)
        {

        }
        return connections;
    }

}
