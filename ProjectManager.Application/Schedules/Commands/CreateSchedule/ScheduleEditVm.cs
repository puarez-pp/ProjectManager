namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public class ScheduleEditVm
{
    public int? Id { get; set; }

    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }

    public List<ScheduleStageEditVm> Stages { get; set; } = new();
}

public class ScheduleStageEditVm
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public List<ScheduleTaskEditVm> Tasks { get; set; } = new();
}

public class ScheduleTaskEditVm
{
    public int? Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }

    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }

    public string AssignedUserId { get; set; }
}
