using MediatR;
using ProjectManager.Application.Settlements.Commands.EditWorkScopeCost;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeCost;

public class GetEditWorkScopeCostQuery : IRequest<EditWorkScopeCostVm>
{
    public int Id { get; set; }
}
