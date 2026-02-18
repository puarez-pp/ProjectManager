using ProjectManager.Application.Projects.Queries.GetProjectBasics;

namespace ProjectManager.Application.Settlements.Queries.GetAssumption;

public class AssumptionsVm
{
    public ProjectBasicsDto Project { get; set; } = new ProjectBasicsDto();
    public AssumptionDto Assumption { get; set; } = new AssumptionDto();
    public WorkScopeSumDto WorkScopesSum { get; set; } = new WorkScopeSumDto();
}