using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Commands.EditInvoice;
using ProjectManager.Application.Settlements.Queries.GetAssumption;

namespace ProjectManager.Application.Settlements.Queries.GetEditInvoice;

public class EditInvoiceVm
{
    public SettlementDto Settlement { get; set; }
    public ProjectBasicsDto Project { get; set; }
    public EditInvoiceCommand Invoice { get; set; }
}
