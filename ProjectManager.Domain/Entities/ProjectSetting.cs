using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public  class ProjectSetting
{
    public int Id { get; set; }
    public ProjectType ProjectType { get; set; }
    public ICollection<ProjectSettingPosition> Positions { get; set; } = new HashSet<ProjectSettingPosition>();
}
