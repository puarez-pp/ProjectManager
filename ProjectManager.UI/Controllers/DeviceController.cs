using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.UI.Controllers
{
    [Authorize()]
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

 
        public async Task<IActionResult> Devices(int Id)
        {
            return View(await Mediator.Send(new GetDevicesQuery { Id = Id }));
        }

        public async Task<IActionResult> AddDevice(int Id)
        {
            ViewData["Plant"] = Plant;
            return View(new AddDevicesCommand { PlantId = Id});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDevice(AddDeviceCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);
                TempData["Success"] = "Dane zostały zaktualizowane.";

            return RedirectToAction("Devices", new { @id = result.Model});
        }

        public async Task<IActionResult> EditDevice(int Id)
        {
            return View(await Mediator.Send(new GetEditDeviceQuery { Id = Id }));
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDevice(EditDeviceCommand commnad)
        {
            
            var result = await MediatorSendValidate(commnad.Position);

            if (!result.IsValid)
                return View(commnad);

            TempData["Success"] = "Dane urządzenia zostały zaktualizowane.";

            return RedirectToAction("Devices", new { @id = commnad.PlantId});
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
            return View(await Mediator.Send(new GetHeadersQuery { Id = Id }));
        }


        public async Task<IActionResult> EditHeader(int Id)
        {
            return View(await Mediator.Send(new GetEditHeaderQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHeader(EditHeaderCommand command)
        {

            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Nazwa nagłówka została zaktualizowana.";

            return RedirectToAction("Headers", new { @id = command.DeviceId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHeaders(EditHeadersCommand command)
        {

            try
            {
                await Mediator.Send(
                    new EditHeadersCommand
                    {
                        Id = command.id
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
