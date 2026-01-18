using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class Tool
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public string Manufacturer { get; set; }
    public ToolStatus ToolStatus { get; set; }
    public DateTime? DateOfPurchase { get; set; }
    public DateTime ValidDate { get; set; }
    public ICollection<ToolRent> Rents { get; set; } = new HashSet<ToolRent>();
}