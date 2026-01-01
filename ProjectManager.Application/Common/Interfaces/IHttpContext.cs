

using Microsoft.AspNetCore.Http;

namespace ProjectManager.Application.Common.Interfaces;
public interface IHttpContext
{
    string AppBaseUrl { get; }
    string IpAddress { get; }
    ISession Session { get; }
}
