using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeOffer;

public class GetEditWorkScopeOfferQuery : IRequest<EditWorkScopeOfferVm>
{
    public int Id { get; set; }
}
