using ProjectManager.Application.Settlements.Commands.AddWorkScopeOffer;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetAddWorkScopeOffer;

public class AddWorkScopeOfferVm
{
    public int SettlementId { get; set; }
    public WorkScopeType ScopeType { get; set; }
    public List<SubContractorBasicsDto> SubContractors { get; set; }
    public AddWorkScopeOfferCommand ScopeOffer { get; set; }
}
