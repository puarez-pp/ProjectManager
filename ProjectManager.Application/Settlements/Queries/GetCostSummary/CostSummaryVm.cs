namespace ProjectManager.Application.Settlements.Queries.GetCostSummary;

public class CostSummaryVm
{
    public decimal Offers { get; set; }
    public decimal Costs { get; set; }
    public decimal Profits { get; set; }
    public List<ScopeCostSummaryDto> ScopeCosts { get; set; }
}