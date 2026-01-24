namespace ProjectManager.Application.Settlements.Queries.GetCostSummary;

public class ScopeCostSummaryDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Offer { get; set; }
    public decimal Cost { get; set; }
    public decimal Profit { get; set; }
}
