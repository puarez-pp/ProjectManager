using ProjectManager.Application.Plants.Queries.GetPlant;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Plants.Extension;

public static class DeviceHeaderExtensions
{
    public static PlantDto ToPlantDto(this Plant plant)
    {
        if (plant == null)
        {
            return null;
        }
        return new PlantDto
        {
            Id = plant.Id,
            Name = plant.Name,
            Location = plant.Location,
            CreatedAt = plant.CreatedAt
        };
    }
}
