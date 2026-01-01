namespace ProjectManager.Domain.Entities;

public class SubContractor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactPerson { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string ZipCode { get; set; }
    public ICollection<DivisionPosition> DivisionItems { get; set; } = new HashSet<DivisionPosition>();
}
