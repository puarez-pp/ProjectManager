using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Users.Queries.GetUserToken;

namespace TelemetryAPI.Controllers;

public class TokensController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Generate(GetUserTokenQuery command)
    {
        var token = await Mediator.Send(command);
        if (token == null) 
            return BadRequest("Invalid username or password.");
        return Ok(token);
    }
}