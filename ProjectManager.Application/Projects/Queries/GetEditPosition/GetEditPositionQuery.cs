using MediatR;

namespace ProjectManager.Application.Projects.Queries.GetEditPosition;

public class GetEditPositionQuery:IRequest<EditPositionVm>
{
    public int Id { get; set; }
}
