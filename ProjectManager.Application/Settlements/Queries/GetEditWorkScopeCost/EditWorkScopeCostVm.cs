using ProjectManager.Application.Settlements.Commands.EditWorkScopeCost;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeCost;

public class EditWorkScopeCostVm
{
    public int SettlementId { get; set; }
    public List<SubContractorBasicsDto> SubContractors { get; set; }
    public EditWorkScopeCostCommand ScopeCost { get; set; }
}
