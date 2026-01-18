using ProjectManager.Application.Projects.Queries.GetPosition;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Posts.Queries.GetCommnents;

public class GetCommentsVm
{
    public ProjectDto Project { get; set; }

    public List<PostDto> Posts { get; set; } = new List<PostDto>();

}