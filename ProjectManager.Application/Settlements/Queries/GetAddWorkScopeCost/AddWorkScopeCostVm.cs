using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Commands.AddWorkScopeCost;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;

namespace ProjectManager.Application.Settlements.Queries.GetAddWorkScopeCost;

public class AddWorkScopeCostVm
{
    public ProjectBasicsDto Project { get; set; }
    public List<SubContractorBasicsDto> SubContractors { get; set; }
    public AddWorkScopeCostCommand ScopeCost { get; set; }
}
