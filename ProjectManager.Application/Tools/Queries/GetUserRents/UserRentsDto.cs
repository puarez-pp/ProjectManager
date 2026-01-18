namespace ProjectManager.Application.Tools.Queries.GetUserRents;

public class UserRentsDto
{
    public int Id { get; set; }
    public string ToolName { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
