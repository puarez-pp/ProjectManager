using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;
using ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeaders;
using ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;
using ProjectManager.Application.DeviceHeaders.Queries.GetEditDeviceHeader;

namespace ProjectManager.UI.Controllers
{
    public class DeviceHeaderController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<DeviceHeaderController> _logger;
        public DeviceHeaderController(IDateTimeService dateTimeService,
            ILogger<DeviceHeaderController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

 
       
        public async Task<IActionResult> Headers(int Id)
        {
            return View(await Mediator.Send(new GetDeviceHeadersQuery { Id = Id }));
        }


        public async Task<IActionResult> EditHeader(int Id)
        {
            return View(await Mediator.Send(new GetEditDeviceHeaderQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHeader(EditDeviceHeaderCommand command)
        {

            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Dane parametru zostały zaktualizowane.";

            return RedirectToAction("Headers", new { @id = command.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHeaders(EditDeviceHeadersCommand command)
        {

            try
            {
                await Mediator.Send(
                    new EditDeviceHeadersCommand
                    {
                        Headers = command.Headers
                    });

                return Json(new { success = true });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, null);
                return Json(new { success = false });
            }
        }

    }
}
