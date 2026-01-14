using MediatR;

namespace ProjectManager.Application.Projects.Queries.GetCommnents;

public class GetCommentsQuery : IRequest<GetCommentsVm>
{
    public int Id { get; set; }
}
