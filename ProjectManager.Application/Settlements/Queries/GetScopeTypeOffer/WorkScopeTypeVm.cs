using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;

public class WorkScopeTypeVm
{
    public WorkScopeType WorkScopeType { get; set; }
    public decimal Margin { get; set; }
    public decimal Total { get; set; }
    public List<WorkScopeDto> WorkScopes { get; set; } = new();
}
