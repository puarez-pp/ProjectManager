using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Devices.Commands.AddDeviceParams;
using ProjectManager.Application.Telemetries.Commands;

namespace TelemetryAPI.Controllers;

[Authorize]
public class TelemetriesController : BaseApiController
{
    [HttpPost("alarms")]
    public async Task<IActionResult> AddAlarm([FromBody] AddAlarmCommand command)
    {
        await Mediator.Send(new AddAlarmCommand
        {
            DeviceId = command.DeviceId,
        });

        return Ok();
    }

    [HttpPost("params")]
    public async Task<IActionResult> AddParams([FromBody] AddDeviceParamsCommand command)
    {
        await Mediator.Send(new AddDeviceParamsCommand
        {
            DeviceId = command.DeviceId,
            DeviceParams = command.DeviceParams
        });

        return Ok();
    }

}
