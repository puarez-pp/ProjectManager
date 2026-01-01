using MediatR;

namespace ProjectManager.Application.Projects.Queries.GetPosition;

public class GetPositionQuery:IRequest<GetPositiontVm>
{
    public int Id { get; set; }
}
