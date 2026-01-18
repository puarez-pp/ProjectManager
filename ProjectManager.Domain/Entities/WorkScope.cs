namespace ProjectManager.Domain.Entities;

public class WorkScope
{
    public int Id { get; set; }
    public int SettlementId { get; set; }
    public Settlement Settlement { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public ICollection<WorkScopeOffer> WorkScopeOffers { get; set; } = new HashSet<WorkScopeOffer>();
    public ICollection<WorkScopeCost> WorkScopeCosts { get; set; } = new HashSet<WorkScopeCost>();
}

