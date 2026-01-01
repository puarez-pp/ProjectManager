using ProjectManager.Domain.Enums;

namespace ProjectManager.Domain.Entities;

public  class Cost
{
    public int Id { get; set; }
    public CostType CostType { get; set; }
    public decimal Price { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
}
