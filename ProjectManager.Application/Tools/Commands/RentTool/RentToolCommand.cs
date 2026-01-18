using MediatR;

namespace ProjectManager.Application.Tools.RentTool.Commands;

public class RentToolCommand : IRequest
{
    public int Id { get; set; }
}

