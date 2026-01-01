using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Commands.AddPosition;
using ProjectManager.Application.Projects.Commands.AddProject;
using ProjectManager.Application.Projects.Commands.DeletePosition;
using ProjectManager.Application.Projects.Commands.AddPositionPost;
using ProjectManager.Application.Projects.Queries.GetCatProjectBasics;
using ProjectManager.Application.Projects.Queries.GetEditDivision;
using ProjectManager.Application.Projects.Queries.GetEditPosition;
using ProjectManager.Application.Projects.Queries.GetEditProject;
using ProjectManager.Application.Projects.Queries.GetPosition;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Domain.Enums;
using ProjectManager.Application.Projects.Queries.GetEditPositionPost;
using ProjectManager.Application.Projects.Commands.EditPositionPost;
using ProjectManager.Application.Projects.Commands.ClosePosition;
using ProjectManager.Application.Projects.Commands.DeletePost;

namespace ProjectManager.UI.Controllers
{
    [Authorize()]
    public class ProjectController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<ProjectController> _logger;
        public ProjectController(IDateTimeService dateTimeService,
            ILogger<ProjectController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

        public async Task<IActionResult> Project(int Id)
        {
            return View(await Mediator.Send(new GetProjectQuery { Id = Id}));
        }
        public async Task<IActionResult> Projects()
        {
            return View(await Mediator.Send(new GetProjectBasicsQuery()));
        }

        public async Task<IActionResult> ProjectsCat(ProjectType Id)
        {
            ViewData["projectType"] = Id;
            return View(await Mediator.Send(new GetCatProjectBasicsQuery { ProjectTypeId = Id }));
            
        }

        public async Task<IActionResult> AddProject()
        {

            return View(new AddProjectCommand ());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProject(AddProjectCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Projekt został dodany.";

            return RedirectToAction("Projects");
        }

        public async Task<IActionResult> EditProject(int Id)
        {
            return View(await Mediator.Send(new GetEditProjectQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProject(EditProjectVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.Project);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane projektu zostały zaktualizowane.";

            return RedirectToAction("Project", new { @id = viewModel.Project.Id });
        }

        public async Task<IActionResult> EditDivision(int Id)
        {
            return View(await Mediator.Send(new GetEditDivisionQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDivision(EditDivisionVm viewModel)
        {
            var result = await MediatorSendValidate(viewModel.Division);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane projektu zostały zaktualizowane.";

            return RedirectToAction("Project", new { @id = viewModel.Project.Id });
        }

        public async Task<IActionResult> Position(int Id)
        {
            return View(await Mediator.Send(new GetPositionQuery { Id = Id }));
        }

        public async Task<IActionResult> AddPosition(int Id, int Project, DivisionType Division)
        {
            ViewData["Project"] = Project;
            ViewData["Division"] = Division;
            return View(new AddPositionCommand { DivisionId = Id});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPosition(AddPositionCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);
                TempData["Success"] = "Dane projektu zostały zaktualizowane.";

            return RedirectToAction("Project", new { @id = result.Model});
        }

        public async Task<IActionResult> EditPosition(int Id)
        {
            return View(await Mediator.Send(new GetEditPositionQuery { Id = Id }));
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPosition(EditPositionVm viewModel)
        {
            
            var result = await MediatorSendValidate(viewModel.Position);

            if (!result.IsValid)
                return View(viewModel);

            TempData["Success"] = "Dane projektu zostały zaktualizowane.";

            return RedirectToAction("Project", new { @id = viewModel.Project.Id});
        }

        [HttpPost]
        public async Task<IActionResult> FinishPosition(int id)
        {
            try
            {
                await Mediator.Send(
                    new ClosePositionCommand
                    {
                        Id = id
                    });

                return Json(new { success = true});
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, null);
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeletePosition(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeletePositionCommand
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

        public async Task<IActionResult> AddPost(int Id, DivisionType Division, string Position)
        {
            ViewData["Division"] = Division;
            ViewData["Position"] = Position;
            return View(new AddPostCommand { PositionId = Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(AddPostCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);
            TempData["Success"] = "Komentarz został dodany.";

            return RedirectToAction("Position", new { @id = command.PositionId });
        }

        public async Task<IActionResult> EditPost(int Id)
        {
            return View(await Mediator.Send(new GetEditPositionPostQuery { Id = Id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(EditPostCommand command)
        {

            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Komentarz został zaktualizowany.";

            return RedirectToAction("Position", new { @id = command.PositionId });
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await Mediator.Send(
                    new DeletePostCommand
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
