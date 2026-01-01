using ProjectManager.Application.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Users.Queries.GetEditUser;
using ProjectManager.Application.Users.Queries.GetUser;
using ProjectManager.Application.Users.Commands.DeleteUser;

namespace ProjectManager.UI.Controllers;

[Authorize(Roles = RolesDict.Pracownik)]
public class UserController : BaseController
{
    private readonly ILogger _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Dashboard()
    {
        return View();
    }

    public async Task<IActionResult> User()
    {
        return View(await Mediator.Send(new GetUserQuery { UserId = UserId }));
    }

    public async Task<IActionResult> EditUser()
    {
        return View(await Mediator.Send(new GetEditUserQuery { UserId = UserId }));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(EditUserVm viewModel)
    {
        var result = await MediatorSendValidate(viewModel.User);

        if (!result.IsValid) 
            return View(viewModel);

        TempData["Success"] = "Dane pracownika zostały zaktualizowane.";

        return RedirectToAction("User");
    }

    [HttpPost]
    [Authorize(Roles = RolesDict.Administrator)]
    public async Task<IActionResult> DeleteUser(string id)
    {
        try
        {
            await Mediator.Send(
                new DeleteUserCommand
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
