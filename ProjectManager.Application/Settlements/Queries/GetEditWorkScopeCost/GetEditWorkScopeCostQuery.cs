using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeCost;

public class GetEditWorkScopeCostQuery : IRequest<EditWorkScopeCostVm>
{
    public int Id { get; set; }
}
