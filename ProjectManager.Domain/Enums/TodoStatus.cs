

using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum TodoStatus
{

    [Display(Name = "W toku")]
    InProgress,

    [Display(Name = "Zakończony")]
    Completed
}