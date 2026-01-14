using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Commands.DeleteDevice;
using ProjectManager.Application.Devices.Queries.GetAddDevice;
using ProjectManager.Application.Devices.Queries.GetAlarms;
using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Application.Devices.Queries.GetEditDevice;

namespace ProjectManager.UI.Controllers
{
    public class DeviceController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<DeviceController> _logger;
        public DeviceController(IDateTimeService dateTimeService,
            ILogger<DeviceController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

 
        public async Task<IActionResult> Device(int id)
        {
            return View(await Mediator.Send(new GetDeviceQuery { Id = id }));
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

            return RedirectToAction("Devices", new { @id = viewModel.Plant.Id });
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

            return RedirectToAction("Devices", new { @id = viewModel.Plant.Id });
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

        public async Task<IActionResult> Alarms(int Id)
        {
            return View(await Mediator.Send(new GetAlarmsQuery { Id = Id }));
        }

    }
}
