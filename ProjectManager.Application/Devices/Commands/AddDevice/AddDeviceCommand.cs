using MediatR;
using ProjectManager.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Devices.Commands.AddDevice;

public class AddDeviceCommand : IRequest
{
    public int PlantId { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa urządzenia' jest wymagane")]
    [DisplayName("Nazwa urządzenia")]
    public string Name { get; set; }
    [DisplayName("Opis")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Pole 'Typ urządzenia' jest wymagane")]
    [DisplayName("Typ urządzenia")]
    public DeviceType DeviceType { get; set; }
}
