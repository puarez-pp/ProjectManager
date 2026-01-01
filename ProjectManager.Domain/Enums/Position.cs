using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum Position
{

    [Display(Name = "Dyrektor")]
    Director,

    [Display(Name = "Kierownik")]
    Manager,

    [Display(Name = "Kierownik projektu")]
    ProjectManager,

    [Display(Name = "Inżynier elektryk")]
    Electric,

    [Display(Name = "Inżynier automatyk")]
    Automatic,

    [Display(Name = "Inżynier mechanik")]
    Designer,

    [Display(Name = "Administracja")]
    Administartion,

    [Display(Name = "Stażysta/ka")]
    Trainee,

    [Display(Name = "Inne stanowisko")]
    Other,
         
    [Display(Name = "Administrator")]
    Administrator
}
