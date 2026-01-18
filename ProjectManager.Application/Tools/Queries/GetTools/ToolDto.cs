using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Tools.Queries.GetTools;

public class ToolDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public ToolStatus ToolStatus { get; set; }
    public DateTime ValidDate { get; set; }
}