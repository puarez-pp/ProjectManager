using MediatR;

namespace ProjectManager.Application.Settlements.Commands.DeleteWorkScopeCost;

public class DeleteWorkScopeCostCommand : IRequest
{
    public int Id { get; set; }
}
