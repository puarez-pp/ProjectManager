using MediatR;

namespace ProjectManager.Application.Devices.Commands.AddScript;

public class GenerateScriptCommand:IRequest
{
    public int Id { get; set; }
}
