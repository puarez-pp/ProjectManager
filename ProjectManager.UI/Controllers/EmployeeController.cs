using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;
using ProjectManager.Application.Employees.Commands.AddEmployee;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GymManager.Application.Employees.Queries.GetEditEmployee;

namespace ProjectManager.UI.Controllers;

[Authorize(Roles = $"{RolesDict.Kierownik},{RolesDict.Administrator}")]
public class EmployeeController : BaseController
{
    private readonly IDateTimeService _dateTimeService;

    public EmployeeController(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;
    }
    
    public async Task<IActionResult> Employees()
    {
        return View(await Mediator.Send(new GetEmployeeBasicsQuery()));
    }

    public async Task<IActionResult> AddEmployee()
    {
        return View(new AddEmployeeCommand());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEmployee(AddEmployeeCommand command)
    {
        var result = await MediatorSendValidate(command);

        if (!result.IsValid)
            return View(command);

        TempData["Success"] = "Pracownik został dodany.";

        return RedirectToAction("Employees");
    }

    public async Task<IActionResult> EditEmployee(string employeeId)
    {
        return View(await Mediator.Send(new GetEditEmployeeQuery { UserId = employeeId }));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditEmployee(EditEmployeeVm viewModel)
    {
        var result = await MediatorSendValidate(viewModel.Employee);

        if (!result.IsValid)
            return View(viewModel);

        TempData["Success"] = "Dane pracownika zostały zaktualizowane.";

        return RedirectToAction("Employees");
    }


}
