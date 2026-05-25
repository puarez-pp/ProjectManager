using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.DeviceHeaders.Commands.ConfirmHeaders;
using ProjectManager.Application.DeviceHeaders.Commands.DeleteHeader;
using ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;
using ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeaders;
using ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;
using ProjectManager.Application.DeviceHeaders.Queries.GetEditDeviceHeader;
using ProjectManager.Application.Devices.Commands.AddScript;
using ProjectManager.Application.Devices.Commands.DeleteDevice;
using ProjectManager.Application.Devices.Queries.GetAddDevice;
using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Application.Devices.Queries.GetDeviceParams;
using ProjectManager.Application.Devices.Queries.GetEditDevice;
using ProjectManager.Application.Devices.Queries.GetSelectParams;

namespace ProjectManager.UI.Controllers;

public class DeviceController : BaseController
{
    private readonly ILogger<DeviceController> _logger;
    public DeviceController(ILogger<DeviceController> logger)
    {
        _logger = logger;
    }


    public async Task<IActionResult> Device(int id)
    {
        return View(await Mediator.Send(new GetDeviceQuery { Id = id }));
    }

    public async Task<IActionResult> SelectParams(int id)
    {
        return View(await Mediator.Send(new GetSelectParamsQuery { Id = id }));
    }

    public async Task<IActionResult> Params(GetDeviceParamsQuery query)
    {
        return View(await Mediator.Send(query));
    }

    public async Task<IActionResult> Alarms(int id)
    {
        return Json(new { success = true});
        //return View(await Mediator.Send(new GetDeviceAlarmsQuery { Id = id }));
    }

    public async Task<IActionResult> AddDevice(int id)
    {
        return View(await Mediator.Send(new GetAddDeviceQuery { Id = id }));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddDevice(AddDeviceVm viewModel)
    {
        var result = await MediatorSendValidate(viewModel.Device);

        if (!result.IsValid)
            return View(viewModel);

        TempData["Success"] = "Urządzenie zostało dodane.";

        return RedirectToAction("Plant", "Plant", new { @id = viewModel.Plant.UserId });
    }

    public async Task<IActionResult> EditDevice(int id)
    {
        return View(await Mediator.Send(new GetEditDeviceQuery { Id = id }));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditDevice(EditDeviceVm viewModel)
    {
        var result = await MediatorSendValidate(viewModel.Device);

        if (!result.IsValid)
            return View(viewModel);

        TempData["Success"] = "Dane zostały zaktualizowane .";

        return RedirectToAction("Plant", "Plant", new { @id = viewModel.Plant.UserId });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteDevice(int id)
    {
        try
        {
            await Mediator.Send(
                new DeleteDeviceCommand
                {
                    Id = id
                });

            return Json(new { success = true });
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, null);
            return Json(new { success = false });
        }
    }
    public async Task<IActionResult> Headers(int Id)
    {
        return View(await Mediator.Send(new GetDeviceHeadersQuery { Id = Id }));
    }


    public async Task<IActionResult> EditHeader(int id)
    {
        var command = await Mediator.Send(new GetEditDeviceHeaderQuery { Id = id });
        return PartialView("_EditHeaderModal", command);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditHeader(EditDeviceHeaderCommand command)
    {

        await Mediator.Send(command);

        return Json(new
        {
            success = true,
            deviceId = command.DeviceId
        });
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmHeaders(int id)
    {
        try
        {
            await Mediator.Send(
                new ConfirmHeadersCommand { Id = id });
            return Json(new { success = true });
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, null);
            return Json(new { success = false });
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteHeader(int id)
    {
        try
        {
            await Mediator.Send(
                new DeleteHeaderCommand { Id = id });
            return Json(new { success = true });
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, null);
            return Json(new { success = false });
        }
    }

    [HttpPost]
    public async Task<IActionResult> GenerateScript(int id)
    {
        try
        {
            await Mediator.Send(
                new GenerateScriptCommand
                {
                    Id = id
                });

            return Json(new { success = true });
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, null);
            return Json(new { success = false });
        }
    }

    public async Task<IActionResult> GetHeadersTable(int id)
    {
        var vm = await Mediator.Send(new GetDeviceHeadersQuery { Id = id });
        return PartialView("_HeadersTable", vm);
    }

}
