using MediatR;

namespace ProjectManager.Application.Projects.Extensions.Commands.FinishProject;

public class FinishProjectCommand:IRequest
{
    public int Id { get; set; }
}
