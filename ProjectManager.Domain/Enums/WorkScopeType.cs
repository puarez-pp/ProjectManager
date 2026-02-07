using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum WorkScopeType
{

    [Display(Name = "Agregat")]
    Agregat,

    [Display(Name = "Instalacje")]
    Installation,

    [Display(Name = "Zarządzanie projektem")]

    Aadministration
}