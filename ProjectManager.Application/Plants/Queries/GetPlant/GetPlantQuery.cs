using MediatR;

namespace ProjectManager.Application.Plants.Queries.GetPlant;

public class GetPlantQuery:IRequest<GetPlantVm>
{
    public int Id { get; set; }
}
