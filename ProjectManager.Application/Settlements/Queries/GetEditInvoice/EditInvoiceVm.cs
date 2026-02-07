using ProjectManager.Application.Settlements.Commands.EditInvoice;

namespace ProjectManager.Application.Settlements.Queries.GetEditInvoice;

public class EditInvoiceVm
{
    public int SettlementId { get; set; }
    public List<WorkScopeDto> WorkScopes { get; set; }
    public EditInvoiceCommand Invoice { get; set; }
}
