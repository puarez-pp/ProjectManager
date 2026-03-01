using MediatR;

namespace ProjectManager.Application.Tools.Commands.RentTool;

public class RentToolCommand : IRequest
{
    public int Id { get; set; }
}

