using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.UI.Controllers
{
    [Authorize()]
    public class PlantController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<PlantController> _logger;
        public PlantController(IDateTimeService dateTimeService,
            ILogger<PlantController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

        public async Task<IActionResult> Plant(int Id)
        {
            return View(await Mediator.Send(new GetPlantQuery { Id = Id}));
 Get       }
        public async Task<IActionResult> Plants()
        {
            return View(await Mediator.Send(new GetPlantsBasicQuery()));
        }

        public async Task<IActionResult> AddPlant()
        {

            return View(new AddPlantCommand ());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPlant(AddPlantCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Instalacja została dodana.";

            return RedirectToAction("Plants");
        }

        public async Task<IActionResult> EditPlant(int Id)
        {
            return View(await Mediator.Send(new GetEditPlantQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPlant(EditPlantVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.Plant);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane instalacji zostały zaktualizowane.";

            return RedirectToAction("Plant", new { @id = viewModel.Plant.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeletePlant(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeletePlantCommand
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
