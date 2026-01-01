namespace ProjectManager.Domain.Entities;
public class Address
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string ZipCode { get; set; }
}
