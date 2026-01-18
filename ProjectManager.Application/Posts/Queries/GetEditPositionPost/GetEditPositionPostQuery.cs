using MediatR;
using ProjectManager.Application.Posts.Commands.EditPositionPost;

namespace ProjectManager.Application.Posts.Queries.GetEditPositionPost;

public class GetEditPositionPostQuery:IRequest<EditPostCommand>
{
    public int Id { get; set; }
}
