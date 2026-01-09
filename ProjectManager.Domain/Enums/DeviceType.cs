using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum DeviceType
{

    [Display(Name = "Generator kogeneracyjny")]
    Engine,

    [Display(Name = "Licznik gazu")]
    GasCounter,

    [Display(Name = "Licznik ciepła")]
    HeatCounter,

    [Display(Name = "Licznik energi elektrycznej")]
    ElectricCounter,

    [Display(Name = "Inny")]
    Other
}
