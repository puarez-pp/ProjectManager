using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetAssumption;

public class WorkScopeBaseAmount
{
    public WorkScopeType WorkScopeType { get; set; }
    public decimal TotalBase { get; set; }
}
