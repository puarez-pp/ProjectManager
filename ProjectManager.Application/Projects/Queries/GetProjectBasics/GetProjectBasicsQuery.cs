using MediatR;

namespace ProjectManager.Application.Projects.Queries.GetProjectBasics;

public class GetProjectBasicsQuery:IRequest<IEnumerable<ProjectBasicsDto>>
{
}
