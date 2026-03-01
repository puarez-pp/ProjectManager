using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;

public class RawOfferItem
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public int Order { get; set; }
    public bool IsUsed { get; set; }
    public UnitType UnitType { get; set; } 
    public int Quantity { get; set; }
    public decimal NetAmount { get; set; }
    public string SubContractor { get; set; } = "";
}

