using MediatR;
using ProjectManager.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Devices.Commands.EditDevice;

public class EditDeviceCommand : IRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa urządzenia' jest wymagane")]
    [DisplayName("Nazwa urządzenia")]
    public string Name { get; set; }
    [DisplayName("Opis")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Pole 'Typ urządzenia' jest wymagane")]
    [DisplayName("Typ urządzenia")]
    public DeviceType DeviceType { get; set; }
}
