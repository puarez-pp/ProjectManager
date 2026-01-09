using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum AlarmType
{

    [Display(Name = "Ostrzeżenie")]
    Alarm,

    [Display(Name = "Wyłączenie awaryjne")]
    Shutdown
}
