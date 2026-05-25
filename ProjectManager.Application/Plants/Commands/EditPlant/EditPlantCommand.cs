using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Plants.Commands.EditPlant;

public class EditPlantCommand : IRequest
{
    public string Id { get; set; }
    [Required(ErrorMessage = "Pole 'Adres e-mail' jest wymagane")]
    [DisplayName("Adres e-mail")]
    [EmailAddress(ErrorMessage = "Pole 'Adres e-mail nie jest prawidłowym adresem e-mail'")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Pole 'Hasło' jest wymagane")]
    [DisplayName("Hasło")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Pole 'Potwierdź hasło' jest wymagane")]
    [DisplayName("Potwierdź hasło")]
    [Compare("Password", ErrorMessage = "Pola 'Hasło' i 'Potwierdź hasło' są różne.")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa instalacji' jest wymagane")]
    [DisplayName("Nazwa instalacji")]
    public string Name { get; set; }

    [DisplayName("Lokalizacja")]
    public string Location { get; set; }
}
