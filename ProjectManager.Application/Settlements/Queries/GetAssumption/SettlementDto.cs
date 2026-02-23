using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Settlements.Queries.GetAssumption;

public class SettlementDto
{
    public int Id { get; set; }
    public AssumptionDto Assumption { get; set; }= new();
    public UserDto User { get; set; }= new();
    public DateTime CreatedAt { get; set; }
    public List<WorkScopeDto> WorkScopes { get; set; } = new();
}