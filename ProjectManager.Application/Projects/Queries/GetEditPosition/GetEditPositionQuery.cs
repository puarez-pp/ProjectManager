using MediatR;
using ProjectManager.Application.Projects.Commands.EditPosition;

namespace ProjectManager.Application.Projects.Queries.GetEditPosition;

public class GetEditPositionQuery:IRequest<EditPositionCommand>
{
    public int Id { get; set; }
}
