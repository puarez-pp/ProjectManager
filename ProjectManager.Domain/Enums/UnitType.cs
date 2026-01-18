using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum UnitType
{

    [Display(Name = "kpl.")]
    Set,

    [Display(Name = "litr")]
    Litr,

    [Display(Name = "Sztuka")]
    Piece,

    [Display(Name = "Inna")]
    Other,
}
