using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Posts.Commands.AddComment;
using ProjectManager.Application.Posts.Commands.AddCommentReply;
using ProjectManager.Application.Posts.Commands.AddPositionPost;
using ProjectManager.Application.Posts.Commands.DeletePost;
using ProjectManager.Application.Posts.Queries.GetCommnents;
using ProjectManager.Domain.Enums;

namespace ProjectManager.UI.Controllers
{
    [Authorize()]
    public class ToolController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger<ToolController> _logger;
        public ToolController(IDateTimeService dateTimeService,
            ILogger<ToolController> logger)
        {
            _dateTimeService = dateTimeService;
            _logger = logger;
        }
        public async Task<IActionResult> AddPost(int Id, DivisionType ProjectScope, string Position)
        {
            ViewData["ProjectScope"] = ProjectScope;
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
