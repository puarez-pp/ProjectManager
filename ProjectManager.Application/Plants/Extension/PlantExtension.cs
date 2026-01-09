using ProjectManager.Application.Plants.Queries.GetPlant;
using ProjectManager.Application.Users.Extensions;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Plants.Extension;

public static class PlantExtension
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
            User = (plant.User.ToUserDto()).FullName,
            CreatedDate = plant.CreatedDate
        };
    }
}
