using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Commands.EditWorkScopeOffer;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeOffer;

public class EditWorkScopeOfferVm
{
    public ProjectBasicsDto Project { get; set; }
    public WorkScopeType ScopeType { get; set; }
    public List<SubContractorBasicsDto> SubContractors { get; set; }
    public EditWorkScopeOfferCommand ScopeOffer { get; set; }
}
