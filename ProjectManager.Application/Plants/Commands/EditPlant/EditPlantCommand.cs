using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Plants.Commands.EditPlant;

public class EditPlantCommand : IRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Pole 'Nazwa instalacji' jest wymagane")]
    [DisplayName("Nazwa instalacji")]
    public string Name { get; set; }
    [DisplayName("Lokalizacja")]
    public string Location { get; set; }
}
