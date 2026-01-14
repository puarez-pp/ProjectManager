using ProjectManager.Application.Projects.Queries.GetPosition;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Projects.Queries.GetCommnents;

public class GetCommentsVm
{
    public ProjectDto Project { get; set; }

    public List<PostDto> Posts { get; set; } = new List<PostDto>();
    public List<List<PostReplyDto>> PostReplies { get; set; } = new List<List<PostReplyDto>>();
    public List<List<PositionPostDto>> PositionPosts { get; set; } = new List<List<PositionPostDto>>();

}