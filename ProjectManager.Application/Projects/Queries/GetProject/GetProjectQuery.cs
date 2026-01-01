using MediatR;

namespace ProjectManager.Application.Projects.Queries.GetProject;

public  class GetProjectQuery:IRequest<GetProjectVm>
{
    public int Id { get; set; }
}
