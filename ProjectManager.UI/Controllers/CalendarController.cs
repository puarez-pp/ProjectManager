using ProjectManager.Application.Dictionaries;
using ProjectManager.Application.EmployeeEvents.Commands.AddEmployeeEvent;
using ProjectManager.Application.EmployeeEvents.Commands.DeleteEmployeeEvent;
using ProjectManager.Application.EmployeeEvents.Commands.UpdateEmployeeEvent;
using ProjectManager.Application.EmployeeEvents.Queries.GetEmployeeEvents;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.UI.Controllers;

[Authorize(Roles = $"{RolesDict.Kierownik},{RolesDict.Administrator}")]
public class CalendarController : BaseController
{
    public async Task<IActionResult> Calendar()
    {
        return View(await Mediator.Send(new GetEmployeeBasicsQuery()));
    }

    public async Task<IActionResult> GetEmployeeEvents()
    {
        return Json(await Mediator.Send(new GetEmployeeEventsQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployeeEvent(
        AddEmployeeEventCommand command)
    {
        await Mediator.Send(command);

        return Json(new
        {
            success = true
        });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateEmployeeEvent(
    UpdateEmployeeEventCommand command)
    {
        await Mediator.Send(command);

        return Json(new
        {
            success = true
        });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteEmployeeEvent(int id)
    {
        await Mediator.Send(new DeleteEmployeeEventCommand { Id = id });

        return Json(new
        {
            success = true
        });
    }
}
