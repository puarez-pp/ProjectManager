namespace ProjectManager.Domain.Entities;

public class WorkScopePositionTemplate
{
    public int Id { get; set; }
    public int WorkScopeTemplateId { get; set; }
    public WorkScopeTemplate WorkScopeTemplate { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}