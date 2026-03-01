using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetCostDetails;

public class RawCostItem
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public CostStatusType CostStatusType { get; set; }
    public int Order { get; set; }
    public UnitType UnitType { get; set; }
    public int Quantity { get; set; }
    public decimal NetAmount { get; set; }
    public string SubContractor { get; set; } = "";
}

