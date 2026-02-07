using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetAddWorkScopeCost;

public class GetAddWorkScopeCostQuery : IRequest<AddWorkScopeCostVm>
{
    public int Id { get; set; }
}
