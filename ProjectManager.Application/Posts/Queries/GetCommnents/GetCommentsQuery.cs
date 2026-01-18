using MediatR;

namespace ProjectManager.Application.Posts.Queries.GetCommnents;

public class GetCommentsQuery : IRequest<GetCommentsVm>
{
    public int Id { get; set; }
}
