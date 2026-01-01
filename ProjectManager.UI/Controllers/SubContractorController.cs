using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;
using ProjectManager.Application.SubContractors.Commands.AddSubContractor;
using ProjectManager.Application.SubContractors.Commands.DeleteSubContractor;
using ProjectManager.Application.SubContractors.Commands.EditSubContractor;
using ProjectManager.Application.SubContractors.GetSubContractorBasics;
using ProjectManager.Application.SubContractors.Queries.GetEditSubContractor;

namespace ProjectManager.UI.Controllers
{
    [Authorize(Roles = $"{RolesDict.Pracownik},{RolesDict.Administrator}")]
    public class SubContractorController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<ClientController> _logger;

        public SubContractorController(IDateTimeService dateTimeService,
                                ILogger<ClientController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

        public async Task<IActionResult> SubContractors()
        {
            return View(await Mediator.Send(new GetSubContractorBasicsQuery()));
        }

        public async Task<IActionResult> AddSubContractor()
        {
            return View(new AddSubContractorCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubContractor(AddSubContractorCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Podwykonawca został dodany.";

            return RedirectToAction("SubContractors");
        }

        public async Task<IActionResult> EditSubContractor(int Id)
        {
            return View(await Mediator.Send(new GetEditSubContractorQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubContractor(EditSubContractorCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Dane podwykonawcy zostały zaktualizowane.";

            return RedirectToAction("SubContractors");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubContractor(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeleteSubContractorCommand
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
