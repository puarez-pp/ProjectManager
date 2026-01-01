using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public class ProjectSettingPosition
{
    public int Id { get; set; }
    public DivisionType Key { get; set; }
    public string Value { get; set; }
    public int Order { get; set; }
    public int ProjectSettingId { get; set; }
    public ProjectSetting ProjectSetting { get; set; }
}


