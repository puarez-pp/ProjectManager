using MediatR;

namespace ProjectManager.Application.Projects.Queries.GetEditProject;

public class GetEditProjectQuery:IRequest<EditProjectVm>
{
    public int Id { get; set; }
}
