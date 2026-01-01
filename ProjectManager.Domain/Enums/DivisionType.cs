

using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum DivisionType
{
    [Display(Name = "Branża mechaniczna")]
    Design,

    [Display(Name = "Branża elektryczna")]
    Electric,

    [Display(Name = "Automatyka")]
    Automatic,
}
