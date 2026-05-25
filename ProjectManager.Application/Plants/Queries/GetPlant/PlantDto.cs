using ProjectManager.Application.Devices.Queries.GetDevice;

namespace ProjectManager.Application.Plants.Queries.GetPlant;
public class PlantDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<DeviceDto> Devices { get; set; }
}
