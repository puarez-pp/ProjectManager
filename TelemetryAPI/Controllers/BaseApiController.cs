using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TelemetryAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class BaseApiController : Controller
{
    private ISender _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    protected string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
