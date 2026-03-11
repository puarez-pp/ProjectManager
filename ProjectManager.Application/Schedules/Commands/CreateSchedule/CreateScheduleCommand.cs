using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Schedules.Commands.CreateSchedule;

public class CreateScheduleCommand : IRequest
{
    public int ProjectId { get; set; }
    [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane")]
    [DisplayName("Nazwa")]
    public string Name { get; set; }
    [DisplayName("Komentarz")]
    public string Comment { get; set; }
}

