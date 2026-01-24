namespace ProjectManager.Application.Settlements.Queries.GetAssumptions;

public class WorkScopeSumDto
{
    public decimal TotalSales { get; set; }
    public decimal TotalCosts { get; set; }
    public decimal TotalDiscountCosts { get; set; }
    public decimal FinalMargin { get; set; }
    public decimal FinalProfit { get; set; }
    public List<WorkScopeSettl> Sales { get; set; }
    public List<WorkScopeSettl> Costs { get; set; }
}