namespace ProjectManager.Domain.Entities;
public class Plant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Device> Devices { get; set; } = new HashSet<Device>();
}
