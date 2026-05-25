using ProjectManager.Application.Common.Models.Devices;

namespace ProjectManager.Application.Common.Interfaces;
public interface IJwtService
{
    AuthenticateResponse GenerateJwtToken(string userId);
}
