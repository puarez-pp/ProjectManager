using ProjectManager.Application.Settlements.Queries.GetInvoices;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Settlements.Queries.GetAssumption;

public class SettlementDto
{
    public int Id { get; set; }
    public AssumptionDto Assumption{ get; set; }
    public UserDto User { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<InvoiceDto> Invoices { get; set; }
    public List<WorkScopeDto> WorkScopes { get; set; }
}