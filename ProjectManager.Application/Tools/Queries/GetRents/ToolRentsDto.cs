using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Tools.Queries.GetRents;

public class ToolRentsDto

{
    public int Id { get; set; }
    public string User { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime? ReturnDate { get; set; }

}