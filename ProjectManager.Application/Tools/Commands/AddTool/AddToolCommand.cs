using MediatR;
using ProjectManager.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Tools.Commands.AddTool;

public class AddToolCommand : IRequest<int>
{
    [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane")]
    [DisplayName("Nazwa")]
    public string Name { get; set; }

    [DisplayName("Numer seryjny")]
    public string SerialNumber { get; set; }
    [DisplayName("Producent")]
    public string Manufacturer { get; set; }
    [DisplayName("Status")]
    public ToolStatus ToolStatus { get; set; }
    [DisplayName("Data zakupu")]
    public DateTime? DateOfPurchase { get; set; }
    [DisplayName("Termin ważności badań")]
    public DateTime ValidDate { get; set; }
}
