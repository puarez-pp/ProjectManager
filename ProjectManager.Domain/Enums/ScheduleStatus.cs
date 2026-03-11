using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum ScheduleStatus
{
    [Display(Name = "Planowane")]
    Planned = 0,
    [Display(Name = "W realizacji")]
    InProgress = 1,
    [Display(Name = "Wykonane")]
    Done = 2,
    [Display(Name = "Zablokowane")]
    Blocked = 3
}
