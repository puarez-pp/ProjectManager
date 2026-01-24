using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetGenerator;

public class WorkScopeCostDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public UnitType UnitType { get; set; }
    public CostStatusType CostStatusType { get; set; }
    public int Quantity { get; set; }
    public decimal NetAmount { get; set; }
    public decimal Total { get; set; }
    public string SubContractor { get; set; }
}