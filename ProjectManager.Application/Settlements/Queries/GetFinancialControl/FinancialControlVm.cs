using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Queries.GetInvoices;

namespace ProjectManager.Application.Settlements.Queries.GetFinancialControl;

public class FinancialControlVm
{
    public ProjectBasicsDto Project { get; set; }
    public List<InvoiceDto> Invoices { get; set; }
    public List<InvoiceSumDto> TotalSums { get; set; }
    public decimal TotalSum { get; set; }
}
