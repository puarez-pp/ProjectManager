using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Queries.GetPosition;

public class GetPositiontVm
{
    public DivisionType DivisionType { get; set; }
    public ProjectBasicsDto Project { get; set; }
    public PositionDto Position { get; set; }
}
