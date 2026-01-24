using MediatR;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetGenerator;

public class GetScopeTypeOfferQuery : IRequest<WorkScopeTypeVm>
{
    public int Id { get; set; }
    public WorkScopeType ScopeType { get; set; }
}
