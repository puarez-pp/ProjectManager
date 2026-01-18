namespace ProjectManager.Domain.Entities;

public class SubConAddress
{
    public int Id { get; set; }
    public int SubContractorId { get; set; }
    public SubContractor SubContractor { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string ZipCode { get; set; }
}
