using MediatR;
using ProjectManager.Application.Projects.Commands.EditPositionPost;

namespace ProjectManager.Application.Projects.Queries.GetEditPositionPost;

public class GetEditPositionPostQuery:IRequest<EditPostCommand>
{
    public int Id { get; set; }
}
