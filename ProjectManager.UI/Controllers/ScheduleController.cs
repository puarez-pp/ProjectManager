using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Schedules.Commands.AddStage;
using ProjectManager.Application.Schedules.Commands.AddTask;
using ProjectManager.Application.Schedules.Commands.UpdateTaskStatus;
using ProjectManager.Application.Schedules.CriticalPath;
using ProjectManager.Application.Schedules.Queries.GetSchedule;

namespace ProjectManager.UI.Controllers;

[Authorize()]
public class ScheduleController : BaseController
{
    private readonly ILogger<ScheduleController> _logger;

    public ScheduleController(ILogger<ScheduleController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Schedule (int id)
    {
        return View(await Mediator.Send(new GetScheduleQuery { Id = id}));
    }


    public async Task<IActionResult> StageList(int scheduleId)
    {
        var vm = await Mediator.Send(new GetScheduleQuery {Id = scheduleId });
        return PartialView("_StageList", vm.Stages);
    }

    public async Task<IActionResult> CriticalPath(int id)
    {
        var result = await Mediator.Send(new GetCriticalPathQuery { ScheduleId = id});
        return View(result);
    }

    //public async Task<IActionResult> TaskList(Guid stageId)
    //{
    //    var vm = await Mediator.Send(new GetTasksQuery(stageId));
    //    return PartialView("_TaskList", vm);
    //}


    [HttpPost]
    public async Task<IActionResult> AddStage(AddStageCommand command)
    {
        var result = await MediatorSendValidate(command);
        if(!result.IsValid)
            return View(command);

        var vm = await Mediator.Send(new GetScheduleQuery { Id = command.ScheduleId });
        return PartialView("_StageList", vm.Stages);
    }


    //[HttpPost]
    //public async Task<IActionResult> AddTask(AddTaskCommand command)
    //{
    //    var result = await MediatorSendValidate(command);
    //    if (!result.IsValid)
    //        return View(command);

    //    var tasks = await Mediator.Send(new GetTasksQuery(command.StageId));
    //    return PartialView("_TaskList", tasks);
    //}


    //[HttpPost]
    //public async Task<IActionResult> UpdateTaskStatus(UpdateTaskStatusCommand command)
    //{
    //    var result = await MediatorSendValidate(command);
    //    if (!result.IsValid)
    //        return View(command);

    //    var tasks = await Mediator.Send(new GetTasksQuery(command.StageId));
    //    return PartialView("_TaskList", tasks);
    //}

}

    

