namespace ProjectManager.Application.Settlements.Queries.GetCostDetails;

public class RawWorkScopeCost
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public int Order { get; set; }
    public IReadOnlyCollection<RawCostItem> Costs { get; set; } = new List<RawCostItem>();
}

