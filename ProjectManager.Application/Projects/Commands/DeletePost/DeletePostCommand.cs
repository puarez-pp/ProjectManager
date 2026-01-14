using MediatR;

namespace ProjectManager.Application.Projects.Commands.DeletePost;

public class DeletePostCommand:IRequest
{
    public int Id { get; set; }
}
