using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.SubContractors.Commands.EditSubContractor;

public class EditSubContractorCommand:IRequest
{
    public int Id { get; set; }

    [DisplayName("Adres e-mail")]
    [EmailAddress(ErrorMessage = "Pole 'Adres e-mail nie jest prawidłowym adresem e-mail'")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane")]
    [DisplayName("Nazwa")]
    public string Name { get; set; }

    [DisplayName("Osoba do kontaktu")]
    public string ContactPerson { get; set; }

    [DisplayName("Numer telefonu")]
    public string PhoneNumber { get; set; }

    [DisplayName("Miejscowość")]
    public string City { get; set; }

    [DisplayName("Ulica")]
    public string Street { get; set; }

    [DisplayName("Numer domu")]
    public string StreetNumber { get; set; }

    [DisplayName("Kod pocztowy")]
    public string ZipCode { get; set; }
}
