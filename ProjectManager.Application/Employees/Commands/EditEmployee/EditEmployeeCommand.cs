using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Employees.Commands.EditEmployee;
public class EditEmployeeCommand : IRequest
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

    [Required(ErrorMessage = "Pole 'Imię' jest wymagane")]
    [DisplayName("Imię")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwisko' jest wymagane")]
    [DisplayName("Nazwisko")]
    public string LastName { get; set; }

    [DisplayName("Stanowisko")]
    [Required(ErrorMessage = "Pole 'Stanowisko' jest wymagane")]
    public int PositionId { get; set; }

    [DisplayName("Bezpośredni przełożony")]
    public string ManagerId { get; set; }

    [DisplayName("Zdjęcie profilowe")]
    public string ImageUrl { get; set; }

    [DisplayName("Wybrane uprawnienia")]
    public List<string> RoleIds { get; set; } = new List<string>();
}
