using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Settlements.Commands.AddSettlement;

public class AddSettlementCommand : IRequest<int>
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Pole 'GP - Agregat' jest wymagane")]
    [DisplayName("GP - Agregat")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość, użyj kropki")]
    public float MarginGen { get; set; }
    [Required(ErrorMessage = "Pole 'GP - Instalacja' jest wymagane")]
    [DisplayName("GP - Instalacja")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość, użyj kropki")]
    public float MarginInstall { get; set; }
    [DisplayName("Plan upustu [%]")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość, użyj kropki")]
    public float Discount { get; set; }
    [DisplayName("Termin płatności")]
    [RegularExpression(@"[0-9]{13}", ErrorMessage = "Wartość nie jest cyfrą")]
    public int Maturity { get; set; }
    [DisplayName("Koszty ogólne firmy")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość, użyj kropki")]
    public float CompanyCost { get; set; }
    [DisplayName("Gwarancja Eneria")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość, użyj kropki")]
    public float CompanyGuarantee { get; set; }
    [DisplayName("Ubezpieczenia")]
    [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość, użyj kropki")]
    public float Insurance { get; set; }
}
