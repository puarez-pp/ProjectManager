using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Settlements.Commands.EditInvoice;

public class EditInvoiceCommand:IRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Pole 'Numer' jest wymagane")]
    [DisplayName("Numer")]
    public string Number { get; set; }
    [Required(ErrorMessage = "Pole 'Data wystawienia' jest wymagane")]
    [DisplayName("Data wystawienia")]
    public DateTime IssueDate { get; set; }

    [DisplayName("Kwota netto")]
    //[RegularExpression(@"^\$?\s?\d{1,3}(\s?\d{3})*(?:[.,]\d{1,2})?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal NetAmount { get; set; }

    [DisplayName("Kwota netto euro")]
    //[RegularExpression(@"^\$?\s?\d{1,3}(\s?\d{3})*(?:[.,]\d{1,2})?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal EuroNetAmount { get; set; }

    [DisplayName("Kurs euro")]
    //[RegularExpression(@"^\$?\s?\d{1,3}(\s?\d{3})*(?:[.,]\d{1,2})?$", ErrorMessage = "Nieprawidłowa wartość")]
    public decimal EuroRate { get; set; }

    [Required(ErrorMessage = "Pole 'Sprzedawca' jest wymagane")]
    [DisplayName("Sprzedawca")]
    public string Vendor { get; set; }

    [Required(ErrorMessage = "Pole 'Numer zamówienia' jest wymagane")]
    [DisplayName("Numer zamówienia")]
    public string OrderNumber { get; set; }
    [Required(ErrorMessage = "Pole 'Zakres' jest wymagane")]
    [DisplayName("Zakres")]
    public int WorkScopeId { get; set; }
}
