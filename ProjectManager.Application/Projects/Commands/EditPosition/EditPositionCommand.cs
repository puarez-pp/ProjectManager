using MediatR;
using ProjectManager.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Projects.Commands.EditPosition;

public class EditPositionCommand:IRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane")]
    [DisplayName("Nazwa")]
    public DivisionPositionType DivisionPositionType { get; set; }

    [Required(ErrorMessage = "Pole 'Wykonawca' jest wymagane")]
    [DisplayName("Wykonawca")]
    public int SubContractorId { get; set; }
    public string DivisionType { get; set; }
    [DisplayName("Uwaga")]
    public string Comment { get; set; }
    [DisplayName("Zakończony")]
    public bool IsCompleted { get; set; }
}
