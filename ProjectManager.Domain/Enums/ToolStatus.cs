

using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum ToolStatus
{
    [Display(Name = "Dostępny")]
    Available,

    [Display(Name = "Wypożyczony")]
    Borrowed,

    [Display(Name = "Serwis/Kalibracja")]
    Servis,

    [Display(Name = "Wycofany")]
    Withdrawn,
}