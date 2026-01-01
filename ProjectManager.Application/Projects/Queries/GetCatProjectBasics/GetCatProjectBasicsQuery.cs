using MediatR;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Queries.GetCatProjectBasics;

public  class GetCatProjectBasicsQuery:IRequest<IEnumerable<ProjectBasicsDto>>
{
    public ProjectType ProjectTypeId { get; set; }
}
