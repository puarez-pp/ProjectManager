using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetGenerator;

public class WorkScopeTypeVm
{
    public WorkScopeType WorkScopeType { get; set; }
    public decimal Margin { get; set; }
    public decimal Total { get; set; }
    public List<WorkScopDto> WorkScopes { get; set; } = new();
}
