using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetAddWorkScopeOffer;

public class GetAddWorkScopeOfferQuery : IRequest<AddWorkScopeOfferVm>
{
    public int Id { get; set; }
}
