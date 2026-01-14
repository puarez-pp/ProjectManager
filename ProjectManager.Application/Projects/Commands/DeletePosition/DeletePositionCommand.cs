using MediatR;

namespace ProjectManager.Application.Projects.Commands.DeletePosition;

public class DeletePositionCommand:IRequest
{
    public int Id { get; set; }
}
