using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Clients.Commands.AddClient;
using ProjectManager.Application.Clients.Commands.DeleteClient;
using ProjectManager.Application.Clients.Commands.EditClient;
using ProjectManager.Application.Clients.Queries.GetClientBasics;
using ProjectManager.Application.Clients.Queries.GetEditClient;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;

namespace ProjectManager.UI.Controllers
{
    [Authorize(Roles = $"{RolesDict.Kierownik},{RolesDict.Administrator}" )]
    public class ClientController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IDateTimeService dateTimeService,
                                ILogger<ClientController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

        public async Task<IActionResult> Clients()
        {
            return View(await Mediator.Send(new GetClientBasicsQuery()));
        }

        public async Task<IActionResult> AddClient()
        {
            return View(new AddClientCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClient(AddClientCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Klient został dodany.";

            return RedirectToAction("Clients");
        }

        public async Task<IActionResult> EditClient(int Id)
        {
            return View(await Mediator.Send(new GetEditClientQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditClient(EditClientCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Dane klienta zostały zaktualizowane.";

            return RedirectToAction("Clients");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeleteClientCommand
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

    }
}
