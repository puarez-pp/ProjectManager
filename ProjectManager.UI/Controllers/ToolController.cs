using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Clients.Commands.AddClient;
using ProjectManager.Application.Clients.Commands.DeleteClient;
using ProjectManager.Application.Clients.Commands.EditClient;
using ProjectManager.Application.Clients.Queries.GetClientBasics;
using ProjectManager.Application.Clients.Queries.GetEditClient;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Todos.Commands.DeleteTodo;
using ProjectManager.Application.Tools.Commands.AddTool;
using ProjectManager.Application.Tools.Commands.EditTool;
using ProjectManager.Application.Tools.Commands.ReturnTool;
using ProjectManager.Application.Tools.Queries.GetEditTool;
using ProjectManager.Application.Tools.Queries.GetTools;
using ProjectManager.Application.Tools.Queries.GetUserRents;
using ProjectManager.Application.Tools.RentTool.Commands;

namespace ProjectManager.UI.Controllers
{
    [Authorize()]
    public class PostController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<PostController> _logger;
        public PostController(IDateTimeService dateTimeService,
            ILogger<PostController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

        public async Task<IActionResult> Tools()
        {
            return View(await Mediator.Send(new GetToolsQuery()));
        }

        public async Task<IActionResult> UserRents()
        {
            return View(await Mediator.Send(new GetUserRentsQuery()));
        }

        public async Task<IActionResult> AddTool()
        {
            return View(new AddClientCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTool(AddToolCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Urządzenie zostało dodane.";

            return RedirectToAction("Tools");
        }

        public async Task<IActionResult> EditTool(int Id)
        {
            return View(await Mediator.Send(new GetEditToolQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTool(EditToolCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Dane urządzenia zostały zaktualizowane.";

            return RedirectToAction("Tools");
        }


        [HttpPost]
        public async Task<IActionResult> RentTool(int id)
        {
            try
            {
                await Mediator.Send(
                    new RentToolCommand
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

        [HttpPost]
        public async Task<IActionResult> ReturnTool(int id)
        {
            try
            {
                await Mediator.Send(
                    new ReturnToolCommand
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
