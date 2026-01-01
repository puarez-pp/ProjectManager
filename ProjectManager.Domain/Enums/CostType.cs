using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum CostType
{

    [Display(Name = "Projekt")]
    Design,

    [Display(Name = "Usługi zlecone")]
    Service,

    [Display(Name = "Zakup towarów")]
    Purchase,

    [Display(Name = "Inne")]
    Other,
}
