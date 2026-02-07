using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Projects.Commands.EditPosition;

public class EditPositionCommand:IRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane")]
    [DisplayName("Nazwa")]
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public bool NotApplicable { get; set; }
    public DateTime? CompletionDate { get; set; }
}
