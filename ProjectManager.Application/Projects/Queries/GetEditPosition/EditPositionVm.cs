
using ProjectManager.Application.Projects.Commands.EditPosition;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Queries.GetEditPosition;

public class EditPositionVm
{
    public ProjectBasicsDto Project { get; set; }
    public DivisionType DivisionType { get; set; }
    public EditPositionCommand Position { get; set; }
    public List<SubContractorBasicsDto> AvaiableSubContractors { get; set; } = new List<SubContractorBasicsDto>();
}
