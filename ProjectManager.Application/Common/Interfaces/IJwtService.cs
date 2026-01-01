using ProjectManager.Application.Common.Models.Inovices;

namespace ProjectManager.Application.Common.Interfaces;
public interface IJwtService
{
    AuthenticateResponse GenerateJwtToken(string userId);
}
