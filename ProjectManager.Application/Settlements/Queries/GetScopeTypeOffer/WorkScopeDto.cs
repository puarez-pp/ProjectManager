using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Settlements.Queries.GetGenerator;

public class WorkScopDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public decimal Total { get; set; }
    public List<WorkScopeOfferDto> Offers { get; set; } = new();
    public List<WorkScopeCostDto> Costs { get; set; } = new();
}