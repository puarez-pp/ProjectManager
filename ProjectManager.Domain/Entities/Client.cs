namespace ProjectManager.Domain.Entities;
public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public string ContactPerson { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Project> Projects { get; set; } = new HashSet<Project>();

}
