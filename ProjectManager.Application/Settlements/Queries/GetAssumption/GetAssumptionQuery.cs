using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetAssumption;

public class GetAssumptionQuery : IRequest<AssumptionsVm>
{
    public int Id { get; set; }
}
