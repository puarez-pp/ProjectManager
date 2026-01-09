using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Plants.Queries.GetPlant;

public class GetPlantVm
{
    public PlantDto Plant { get; set; }
    public List<Device> Devices { get; set; } = new List<Device>();
}