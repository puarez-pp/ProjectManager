using ProjectManager.Application.Settlements.Commands.AddInvoice;

namespace ProjectManager.Application.Settlements.Queries.GetAddInvoice;

public class AddInvoiceVm
{
    public int SettlementId { get; set; }
    public List<WorkScopeDto> WorkScopes { get; set; }
    public AddInvoiceCommand Invoice { get; set; }
}
