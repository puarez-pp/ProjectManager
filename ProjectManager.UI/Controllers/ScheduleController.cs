using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Schedules.Commands.CreateSchedule;
using ProjectManager.Application.Schedules.Commands.UpdateTaskStatus;
using ProjectManager.Application.Schedules.Queries.GetAddSchedule;
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
        var vm = await Mediator.Send(new GetSchedulesQuery { ProjectId = projectId});
        ViewBag.ProjectId = projectId;
        return View(vm);
    }

    public async Task<IActionResult> Schedule(int id)
    {
        var vm = await Mediator.Send(new GetScheduleQuery { Id = id});
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
    public async Task<IActionResult> Create(ScheduleEditVm model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var id = await Mediator.Send(new CreateScheduleCommand { Model = model});
        return RedirectToAction(nameof(Schedule), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var vm = await Mediator.Send(new GetEditScheduleQuery { Id = id});
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ScheduleEditVm model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await Mediator.Send(new UpdateScheduleCommand { Model = model});
        return RedirectToAction(nameof(Schedule), new { id = model.Id });
    }

}

    

