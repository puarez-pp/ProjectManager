using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class WorkScopeOffer
{
    public int Id { get; set; }
    public int WorkScopeId { get; set; }
    public WorkScope WorkScope { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public int Order { get; set; }
    public bool IsUsed { get; set; }
    public UnitType UnitType { get; set; }
    public int Quantity { get; set; }
    public decimal NetAmount { get; set; }
    public decimal EuroNetAmount { get; set; }
    public decimal EuroRate { get; set; }
    public int SubContractorId { get; set; }
    public SubContractor SubContractor { get; set; }
}