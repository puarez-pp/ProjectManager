using ProjectManager.Application.Settlements.Commands.EditWorkScopeOffer;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeOffer;

public class EditWorkScopeOfferVm
{
    public int SettlementId { get; set; }
    public WorkScopeType ScopeType { get; set; }
    public List<SubContractorBasicsDto> SubContractors { get; set; }
    public EditWorkScopeOfferCommand ScopeOffer { get; set; }
}
