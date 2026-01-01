using MediatR;

namespace ProjectManager.Application.Projects.Commands.ClosePosition;

public class ClosePositionCommand:IRequest
{
    public int Id { get; set; }
}
