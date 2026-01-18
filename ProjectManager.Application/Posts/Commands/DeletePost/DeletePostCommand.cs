using MediatR;

namespace ProjectManager.Application.Posts.Commands.DeletePost;

public class DeletePostCommand:IRequest
{
    public int Id { get; set; }
}
