using ProjectManager.Application.Projects.Queries.GetProject;
using ProjectManager.Application.Settlements.Commands.EditSettlement;

namespace ProjectManager.Application.Settlements.Queries.GetEditSettlement;

public class EditSettlementVm
{
    public ProjectDto Project { get; set; }
    public EditSettlementCommand Settlement { get; set; }
}