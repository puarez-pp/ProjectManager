using MediatR;
using ProjectManager.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Projects.Commands.AddPosition;

public class AddPositionCommand : IRequest<int>
{

    [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane")]
    [DisplayName("Nazwa")]
    public DivisionPositionType DivisionPositionType { get; set; }

    public int DivisionId { get; set; }

    [DisplayName("Uwaga")]
    public string Comment { get; set; }

}
