using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Commands.AddInvoice;
using ProjectManager.Application.Settlements.Queries.GetAssumption;

namespace ProjectManager.Application.Settlements.Queries.GetAddInvoice;

public class AddInvoiceVm
{
    public SettlementDto Settlement { get; set; }
    public ProjectBasicsDto Project { get; set; }
    public AddInvoiceCommand Invoice { get; set; }
}
