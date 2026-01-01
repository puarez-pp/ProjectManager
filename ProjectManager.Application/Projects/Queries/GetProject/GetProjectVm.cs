using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Queries.GetProject;

public class GetProjectVm
{
    public ProjectDto Project { get; set; }
    public List<Division> Divisions { get; set; } = new List<Division>();
    public List<List<DivisionPosition>> Positions { get; set; } = new List<List<DivisionPosition>>();
}
