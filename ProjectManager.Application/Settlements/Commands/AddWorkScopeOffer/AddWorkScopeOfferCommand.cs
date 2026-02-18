using MediatR;
using ProjectManager.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Settlements.Commands.AddWorkScopeOffer;

public class AddWorkScopeOfferCommand:IRequest

{
    public int WorkScopeId { get; set; }
    [Required(ErrorMessage = "Pole 'Opis' jest wymagane")]
    [DisplayName("Opis")]
    public string Description { get; set; }

    [DisplayName("Uwagi")]
    public string Comment { get; set; }
    [DisplayName("Aktywny")]
    public bool IsUsed { get; set; }

    [DisplayName("Ilość")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Wartość musi być liczbą całkowitą")]
    public int Quantity { get; set; }
    [Required(ErrorMessage = "Pole 'Jednostka' jest wymagane")]
    [DisplayName("Jednostka")]
    public UnitType UnitType { get; set; }

    [DisplayName("Cena netto")]
    [RegularExpression(@"^[0-9]+([.,][0-9]{1,2})?$", ErrorMessage = "Podaj poprawną kwotę (maks. 2 miejsca po przecinku).")]
    public decimal NetAmount { get; set; }
    [DisplayName("Cena netto Euro")]
    [RegularExpression(@"^[0-9]+([.,][0-9]{1,2})?$", ErrorMessage = "Podaj poprawną kwotę (maks. 2 miejsca po przecinku).")]
    public decimal EuroNetAmount { get; set; }
    [DisplayName("Kurs euro")]
    [RegularExpression(@"^[0-9]+([.,][0-9]{1,2})?$", ErrorMessage = "Podaj poprawną kwotę (maks. 2 miejsca po przecinku).")]
    public decimal EuroRate { get; set; }

    [DisplayName("Wykonawca")]
    public int SubContractorId { get; set; }
}

 
