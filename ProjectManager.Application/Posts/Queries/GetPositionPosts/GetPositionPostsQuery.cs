using MediatR;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Posts.Queries.GetPositionPosts;

public class GetPositionPostsQuery:IRequest<List<PositionPostDto>>
{
    public int Id { get; set; }
}
