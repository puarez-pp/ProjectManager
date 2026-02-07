using MediatR;

namespace ProjectManager.Application.Projects.Commands.FinishPosition;

public class FinishPositionCommand : IRequest
{
    public int Id { get; set; }
    public bool IsCompleted { get; set; }

}
