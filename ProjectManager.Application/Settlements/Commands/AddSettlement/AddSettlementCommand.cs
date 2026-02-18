using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Settlements.Commands.AddSettlement;

public class AddSettlementCommand : IRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Pole 'GP - Agregat' jest wymagane")]
    [DisplayName("GP - Agregat")]
    [RegularExpression(@"^\$?\s?(?:\d{1,2})(?:[.,]\d{1,2})?$", ErrorMessage = "Wartość musi być liczbą mniejszą niż 100")]

    public decimal MarginGen { get; set; }
    [Required(ErrorMessage = "Pole 'GP - Instalacja' jest wymagane")]
    [DisplayName("GP - Instalacja")]
    [RegularExpression(@"^\$?\s?(?:\d{1,2})(?:[.,]\d{1,2})?$", ErrorMessage = "Wartość musi być liczbą mniejszą niż 100")]
    public decimal MarginInstall { get; set; }
    [DisplayName("Plan upustu [%]")]
    [RegularExpression(@"^\$?\s?(?:\d{1,2})(?:[.,]\d{1,2})?$", ErrorMessage = "Wartość musi być liczbą mniejszą niż 100")]
    public decimal Discount { get; set; }
    [DisplayName("Termin płatności")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Wartość musi być liczbą całkowitą")]

    public int Maturity { get; set; }
    [DisplayName("Koszty ogólne firmy")]
    [RegularExpression(@"^\$?\s?(?:\d{1,2})(?:[.,]\d{1,2})?$", ErrorMessage = "Wartość musi być liczbą mniejszą niż 100")]
    public decimal CompanyCost { get; set; }
    [DisplayName("Gwarancja Eneria")]
    [RegularExpression(@"^\$?\s?(?:\d{1,2})(?:[.,]\d{1,2})?$", ErrorMessage = "Wartość musi być liczbą mniejszą niż 100")]
    public decimal CompanyGuarantee { get; set; }
    [DisplayName("Ubezpieczenia")]
    [RegularExpression(@"^\$?\s?(?:\d{1,2})(?:[.,]\d{1,2})?$", ErrorMessage = "Wartość musi być liczbą mniejszą niż 100")]
    public decimal Insurance { get; set; }
}
