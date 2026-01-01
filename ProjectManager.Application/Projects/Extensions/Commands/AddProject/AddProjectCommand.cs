using MediatR;
using ProjectManager.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Application.Projects.Commands.AddProject;

public class AddProjectCommand:IRequest
{
    [DisplayName("Typ projektu")]
    public ProjectType ProjectType { get; set; }

    [DisplayName("Status projektu")]
    public ProjectStatus ProjectStatus { get; set; }

    [DisplayName("Uwagi do projektu")]
    public string Comment { get; set; }

    [DisplayName("Numer projektu")]
    public string Number { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa projektu' jest wymagane")]
    [DisplayName("Nazwa projektu")]
    public string Name { get; set; }

    [DisplayName("Link do Sharepoint")]
    public string Sharepoint { get; set; }
}
