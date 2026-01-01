

using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum ProjectStatus
{
    [Display(Name = "Wprowadzony")]
    InPreparation,

    [Display(Name = "W realizacji")]
    InProgress,

    [Display(Name = "Zakończony")]
    Completed
}
