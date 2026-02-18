using ProjectManager.Application.Projects.Queries.GetProjectBasics;

namespace ProjectManager.Application.Settlements.Queries.GetCostSummary;

public class CostSummaryVm
{
    public ProjectBasicsDto Project { get; set; }
    public decimal Offers { get; set; }
    public decimal Costs { get; set; }
    public decimal Profits { get; set; }
    public List<ScopeCostSummaryDto> ScopeCosts { get; set; }
}