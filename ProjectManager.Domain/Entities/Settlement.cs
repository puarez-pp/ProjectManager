namespace ProjectManager.Domain.Entities;

public class Settlement
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public Assumption Assumption { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    public ICollection<WorkScope> WorkScopes { get; set; } = new HashSet<WorkScope>();
}
