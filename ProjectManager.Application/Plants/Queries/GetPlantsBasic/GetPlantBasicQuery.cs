using MediatR;

namespace ProjectManager.Application.Plants.Queries.GetPlantsBasic;

public class GetPlantBasicQuery:IRequest<IEnumerable<PlantBasicDto>>
{
}
