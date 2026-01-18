using MediatR;

namespace ProjectManager.Application.Tools.Commands.ReturnTool;

public class ReturnToolCommand : IRequest
{
    public int Id { get; set; }
}
