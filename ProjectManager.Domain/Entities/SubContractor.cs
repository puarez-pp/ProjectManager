namespace ProjectManager.Domain.Entities;

public class SubContractor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactPerson { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public SubConAddress Address { get; set; }
    public ICollection<ProjectScopePosition> DivisionItems { get; set; } = new HashSet<ProjectScopePosition>();
    public ICollection<WorkScopeOffer> WorkScopeOffers { get; set; } = new HashSet<WorkScopeOffer>();
    public ICollection<WorkScopeCost> WorkScopeCosts { get; set; } = new HashSet<WorkScopeCost>();
}
