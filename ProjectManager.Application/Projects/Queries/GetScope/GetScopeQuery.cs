using MediatR;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Projects.Queries.GetScopes;

public class GetScopeQuery:IRequest<ProjectScopeDto>
{
    public int Id { get; set; }
}
