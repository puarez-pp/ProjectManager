using ProjectManager.Application.Dictionaries;
using ProjectManager.Application.Settings.Commands.EditSettings;
using ProjectManager.Application.Settings.Queries.GetSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.UI.Controllers;

[Authorize(Roles = RolesDict.Administrator)]
public class SettingsController : BaseController
{
    public async Task<IActionResult> Settings()
    {
        return View(await Mediator.Send(new GetSettingsQuery()));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditSettings(IList<SettingsDto> model)
    {
        var command = new EditSettingsCommand();
        model.ToList().ForEach(x => command.Positions.AddRange(x.Positions));

        await Mediator.Send(command);

        TempData["Success"] = "Ustawienia zostały zaktualizowane.";

        return RedirectToAction("Settings");
    }
}
