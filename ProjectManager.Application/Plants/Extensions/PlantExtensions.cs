using ProjectManager.Application.Plants.Commands.EditPlant;
using ProjectManager.Application.Plants.Queries.GetPlant;
using ProjectManager.Application.Plants.Queries.GetPlantsBasic;
using ProjectManager.Application.Users.Extensions;
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
            User = (plant.User.ToUserDto()).FullName,
            CreatedAt = plant.CreatedAt
        };
    }
    public static GetPlantsBasicDto ToPlantsBasicDto(this Plant plant)
    {
        if (plant == null)
        {
            return null;
        }
        return new GetPlantsBasicDto
        {
            Id = plant.Id,
            Name = plant.Name,
            Location = plant.Location,
        };
    }
    public static EditPlantCommand ToEditPlantCommand(this Plant plant)
    {
        if (plant == null)
        {
            return null;
        }
        return new EditPlantCommand
        {
            Id = plant.Id,
            Name = plant.Name,
            Location = plant.Location,
        };
    }
}
