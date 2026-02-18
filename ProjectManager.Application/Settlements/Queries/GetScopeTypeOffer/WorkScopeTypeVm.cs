using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;

public class WorkScopeTypeVm
{
    public ProjectBasicsDto Project { get; set; } = new ProjectBasicsDto();
    public WorkScopeType WorkScopeType { get; set; }
    public decimal Margin { get; set; }
    public decimal Total { get; set; }
    public List<WorkScopeDto> WorkScopes { get; set; } = new();
}
