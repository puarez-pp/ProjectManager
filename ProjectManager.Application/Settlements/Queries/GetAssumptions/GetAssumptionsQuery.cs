using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetAssumptions;

public class GetAssumptionsQuery : IRequest<AssumptionsVm>
{
    public int Id { get; set; }
}
