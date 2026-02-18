using ProjectManager.Application.Projects.Queries.GetProjectBasics;

namespace ProjectManager.Application.Settlements.Queries.GetCostDetails;

public class CostDetailsVm
{
    public ProjectBasicsDto Project { get; set; }
    public decimal Total { get; set; }
    public List<WorkScopeDto> WorkScopes { get; set; }
}
