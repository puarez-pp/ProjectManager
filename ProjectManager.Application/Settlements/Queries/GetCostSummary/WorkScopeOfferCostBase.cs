using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetCostSummary;

public class WorkScopeOfferCostBase
{
    public int WorkScopeId { get; set; }
    public WorkScopeType WorkScopeType { get; set; }
    public string Description { get; set; } = ""; 
    public int Order { get; set; }
    public decimal SumNet { get; set; }
}
