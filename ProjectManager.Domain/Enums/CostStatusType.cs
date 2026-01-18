using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Domain.Enums;

public enum CostStatusType
{

    [Display(Name = "Założenie kosztów")]
    Assumption,

    [Display(Name = "Zamówienie/Zlecenie")]
    Order,

    [Display(Name = "Faktura")]
    Invoice,

    [Display(Name = "Inne")]
    Other,
}
