using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Projects.Commands.EditDivision;

public class EditDivisionCommand:IRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole 'Inżynier prowadzący' jest wymagane")]
    [DisplayName("Inżynier prowadzący")]
    public string UserId { get; set; }

    public string DivisionType { get; set; }
    
}
