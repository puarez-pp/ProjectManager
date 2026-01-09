using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Plants.Queries.GetPlant;
public class PlantDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string User { get; set; }
    public DateTime CreatedDate { get; set; }
}
