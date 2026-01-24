using MediatR;
using ProjectManager.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Settlements.Commands.AddWorkScopeOffer;

public class AddWorkScopeOfferCommand:IRequest<int>

{
    public int WorkScopeId { get; set; }
    [Required(ErrorMessage = "Pole 'Opis' jest wymagane")]
    [DisplayName("Opis")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Pole 'Uwagi' jest wymagane")]
    [DisplayName("Uwagi")]
    public string Comment { get; set; }
    [DisplayName("Aktywny")]
    public bool IsUsed { get; set; }

    [DisplayName("Ilość")]
    //[RegularExpression(@"[0-9]{13}", ErrorMessage = "Wartość nie jest cyfrą")]
    public int Quantity { get; set; }
    [Required(ErrorMessage = "Pole 'Jednostka' jest wymagane")]
    [DisplayName("Jednostka")]
    public UnitType UnitType { get; set; }

    [DisplayName("Cena netto")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal NetAmount { get; set; }
    [DisplayName("Cena netto Euro")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal EuroNetAmount { get; set; }
    [DisplayName("Kurs euro")]
    //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal EuroRate { get; set; }
    [Required(ErrorMessage = "Pole 'Wykonawca' jest wymagane")]
    [DisplayName("Wykonawca")]
    public int SubContractorId { get; set; }
}

 
