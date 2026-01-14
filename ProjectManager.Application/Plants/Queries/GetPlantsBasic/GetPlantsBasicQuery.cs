using MediatR;

namespace ProjectManager.Application.Plants.Queries.GetPlantsBasic;

public class GetPlantsBasicQuery:IRequest<IEnumerable<GetPlantsBasicDto>>
{
}
