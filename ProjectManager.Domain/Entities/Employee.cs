using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;
public class Employee
{
    public int Id { get; set; }
    public Position Position { get; set; }
    public string Phone { get; set; }
    public string ManagerId { get; set; }
    public string ImageUrl { get; set; }
    public string WebsiteUrl { get; set; }
    public string WebsiteRaw { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}
