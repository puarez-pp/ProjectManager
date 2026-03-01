namespace ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;

public class RawWorkScopeOffer
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public int Order { get; set; }
    public IReadOnlyCollection<RawOfferItem> Offers { get; set; } = new List<RawOfferItem>();
}

