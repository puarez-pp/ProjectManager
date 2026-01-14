using MediatR;

namespace ProjectManager.Application.Projects.Commands.FinishProject;

public class FinishProjectCommand:IRequest
{
    public int Id { get; set; }
}
