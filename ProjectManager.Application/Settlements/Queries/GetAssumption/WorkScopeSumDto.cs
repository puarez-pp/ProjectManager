namespace ProjectManager.Application.Settlements.Queries.GetAssumption;

public class WorkScopeSumDto
{
    public decimal TotalSales { get; set; }
    public decimal TotalImplementation { get; set; }
    public decimal TotalOverheads  { get; set; }
    public decimal TotalCosts { get; set; }
    public decimal TotalAfterDiscount { get; set; }
    public decimal Margin { get; set; }
    public decimal FinalMargin { get; set; }
    public decimal FinalProfit { get; set; }
    public List<WorkScopeSettl> Sales { get; set; } = new List<WorkScopeSettl>();
    public List<WorkScopeSettl> Costs { get; set; } = new List<WorkScopeSettl>();
}