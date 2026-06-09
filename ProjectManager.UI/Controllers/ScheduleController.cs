using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Schedules.Commands.CreateSchedule;
using ProjectManager.Application.Schedules.Commands.UpdateTaskStatus;
using ProjectManager.Application.Schedules.Queries.GetEditSchedule;
using ProjectManager.Application.Schedules.Queries.GetSchedule;
using ProjectManager.Application.Schedules.Queries.GetSchedules;

namespace ProjectManager.UI.Controllers;

[Authorize()]
public class ScheduleController : BaseController
{
    private readonly ILogger<ScheduleController> _logger;

    public ScheduleController(ILogger<ScheduleController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Schedules(int projectId)
    {
        var vm = await Mediator.Send(new GetSchedulesQuery { Id = projectId});
        return View(vm);
    }

    public async Task<IActionResult> Details(int id)
    {
        var vm = await Mediator.Send(new GetScheduleDetailsQuery { Id = id});
        return View(vm);
    }

    public async Task<IActionResult> CriticalPath(int id)
    {
        var vm = await Mediator.Send(new GetScheduleCriticalPathQuery { Id = id});
        return View(vm);
    }

    [HttpGet]
    public IActionResult Create(int projectId)
    {
        var vm = new ScheduleEditVm { ProjectId = projectId };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateScheduleCommand model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var id = await Mediator.Send(model);
        return RedirectToAction(nameof(CriticalPath), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var vm = await Mediator.Send(new GetEditScheduleQuery { Id = id});
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateScheduleCommand model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await Mediator.Send(model);
        return RedirectToAction(nameof(CriticalPath), new { id = model.Id });
    }

}

    

