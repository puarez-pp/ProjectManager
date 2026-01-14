using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Clients.Commands.DeleteClient;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Commands.AddComment;
using ProjectManager.Application.Projects.Commands.AddCommentReply;
using ProjectManager.Application.Projects.Commands.AddPosition;
using ProjectManager.Application.Projects.Commands.AddPositionPost;
using ProjectManager.Application.Projects.Commands.AddProject;
using ProjectManager.Application.Projects.Commands.ClosePosition;
using ProjectManager.Application.Projects.Commands.DeletePosition;
using ProjectManager.Application.Projects.Commands.DeletePost;
using ProjectManager.Application.Projects.Commands.EditPositionPost;
using ProjectManager.Application.Projects.Commands.FinishProject;
using ProjectManager.Application.Projects.Queries.GetCatProjectBasics;
using ProjectManager.Application.Projects.Queries.GetCommnents;
using ProjectManager.Application.Projects.Queries.GetEditDivision;
using ProjectManager.Application.Projects.Queries.GetEditPosition;
using ProjectManager.Application.Projects.Queries.GetEditPositionPost;
using ProjectManager.Application.Projects.Queries.GetEditProject;
using ProjectManager.Application.Projects.Queries.GetPosition;
using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Todos.Commands.FinishTodo;
using ProjectManager.Domain.Enums;

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

        public async Task<IActionResult> ProjComments(int Id)
        {
            return View(await Mediator.Send(new GetCommentsQuery { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int id)
        {
            try
            {
                await Mediator.Send(
                    new AddCommentCommand
                    {
                        ProjectId = id
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
        public async Task<IActionResult> AddCommentReply(int id)
        {
            try
            {
                await Mediator.Send(
                    new AddCommentReplyCommand
                    {
                        PostId = id
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
