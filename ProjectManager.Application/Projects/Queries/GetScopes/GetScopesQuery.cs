using MediatR;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Projects.Queries.GetScopes;

public class GetScopesQuery:IRequest<List<ProjectScopeDto>>
{
    public int Id { get; set; }
}
