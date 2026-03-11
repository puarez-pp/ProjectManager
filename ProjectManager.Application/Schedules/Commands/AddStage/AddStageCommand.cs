using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Schedules.Commands.AddStage;

public class AddStageCommand : IRequest
{
    public int ScheduleId { get; set; }
    [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane")]
    [DisplayName("Nazwa")]
    public string Name { get; set; }
    [DisplayName("Opis")]
    public string Description { get; set; }
}
