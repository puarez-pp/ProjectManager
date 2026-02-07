using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Posts.Commands.AddPositionPost;
using ProjectManager.Application.Posts.Queries.GetPositionPosts;
using ProjectManager.Application.Projects.Commands.AddPosition;
using ProjectManager.Application.Projects.Commands.AddProject;
using ProjectManager.Application.Projects.Commands.DeletePosition;
using ProjectManager.Application.Projects.Commands.EditPosition;
using ProjectManager.Application.Projects.Commands.FinishPosition;
using ProjectManager.Application.Projects.Commands.FinishProject;
using ProjectManager.Application.Projects.Queries.GetCatProjectBasics;
using ProjectManager.Application.Projects.Queries.GetEditPosition;
using ProjectManager.Application.Projects.Queries.GetEditProject;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Domain.Enums;

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

        public async Task<IActionResult> Project(int id)
        {
            return View(await Mediator.Send(new GetProjectQuery { Id = id}));
        }
        public async Task<IActionResult> Scopes(int id)
        {
            return PartialView("_ScopesAccordion", await Mediator.Send(new GetProjectQuery { Id = id }));
        }

        public async Task<IActionResult> Projects()
        {
            return View(await Mediator.Send(new GetProjectBasicsQuery()));
        }
        [HttpGet]
        public async Task<IActionResult> PositionPosts(int id)
        {
            ViewBag.Id = id;
            return PartialView("_PositionPosts", await Mediator.Send(new GetPositionPostsQuery { Id = id }));
        }

        public async Task<IActionResult> ProjectsCat(ProjectType id)
        {
            ViewData["projectType"] = id;
            return View(await Mediator.Send(new GetCatProjectBasicsQuery { ProjectTypeId = id }));
            
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

        public async Task<IActionResult> EditProject(int id)
        {
            return View(await Mediator.Send(new GetEditProjectQuery { Id = id }));
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

        [HttpPost]
        public async Task<IActionResult> FinishProject(int id)
        {
            try
            {
                await Mediator.Send(
                    new FinishProjectCommand
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

        public async Task<IActionResult> AddPosition(int id)
        {
            return PartialView("_AddPositionModal", new AddPositionCommand { ProjectScopeId = id});
  
        }


        [HttpPost]
        public async Task<IActionResult> AddPosition(AddPositionCommand command)
        {
            await Mediator.Send(command);

            return Json(new
            {
                success = true
            });
        }

        public async Task<IActionResult> EditPosition(int id)
        {
            var command = await Mediator.Send(new GetEditPositionQuery { Id = id});
            return PartialView("_EditPositionModal", command);

        }

        [HttpPost]
        public async Task<IActionResult> EditPosition(EditPositionCommand command)
        {
            await Mediator.Send(command);

            return Json(new
            {
                success = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> FinishPosition(int id, bool isCompleted)
        {

            await Mediator.Send(
                new FinishPositionCommand
                {
                    Id = id,
                    IsCompleted = isCompleted
                });

            return Json(new { success = true});
        }

        public async Task<IActionResult> AddPositionPost(int id)
        {
            return PartialView("_AddPositionPostModal", new AddPostCommand { PositionId = id });

        }


        [HttpPost]
        public async Task<IActionResult> AddPositionPost(AddPostCommand command)
        {
            await Mediator.Send(command);

            return Json(new
            {
                success = true
            });
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

    }
}
