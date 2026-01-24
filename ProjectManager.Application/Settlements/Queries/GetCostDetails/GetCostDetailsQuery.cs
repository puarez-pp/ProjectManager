using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetCostDetails;

public class GetCostDetailsQuery : IRequest<CostDetailsVm>
{
    public int Id { get; set; }
}
