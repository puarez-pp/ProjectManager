using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Settlements.Commands.AddSettlement;

public class AddSettlementCommand : IRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Pole 'GP - Agregat' jest wymagane")]
    [DisplayName("GP - Agregat")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal MarginGen { get; set; }
    [Required(ErrorMessage = "Pole 'GP - Instalacja' jest wymagane")]
    [DisplayName("GP - Instalacja")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal MarginInstall { get; set; }
    [DisplayName("Plan upustu [%]")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal Discount { get; set; }
    [DisplayName("Termin płatności")]
    //[RegularExpression(@"[0-9]{13}", ErrorMessage = "Wartość nie jest cyfrą")]
    public int Maturity { get; set; }
    [DisplayName("Koszty ogólne firmy")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal CompanyCost { get; set; }
    [DisplayName("Gwarancja Eneria")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal CompanyGuarantee { get; set; }
    [DisplayName("Ubezpieczenia")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal Insurance { get; set; }
}
