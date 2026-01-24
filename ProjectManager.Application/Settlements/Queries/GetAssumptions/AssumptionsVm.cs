using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Settlements.Queries.GetCostSummary;

namespace ProjectManager.Application.Settlements.Queries.GetAssumptions;

public class AssumptionsVm
{
    public AssumptionDto Assumption { get; set; }
    public WorkScopeSumDto WorkScopesSum { get; set; }
}