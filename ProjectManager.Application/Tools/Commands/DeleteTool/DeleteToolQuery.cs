using MediatR;

namespace ProjectManager.Application.Tools.Commands.DeleteTool;

public class DeleteToolQuery : IRequest
{
    public int Id { get; set; }
}
