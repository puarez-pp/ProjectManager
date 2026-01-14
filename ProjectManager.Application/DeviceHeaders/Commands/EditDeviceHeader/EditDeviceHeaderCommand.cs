using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;

public class EditDeviceHeaderCommand: IRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa parametru' jest wymagane")]
    [DisplayName("Nazwa parametru")]
    public string Name { get; set; }
    [DisplayName("Opis")]
    public string Description { get; set; }
    public bool Used { get; set; }
}
