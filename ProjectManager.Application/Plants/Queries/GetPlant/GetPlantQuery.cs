using MediatR;

namespace ProjectManager.Application.Plants.Queries.GetPlant;

public class GetPlantQuery:IRequest<PlantDto>
{
    public string Id { get; set; }
}
