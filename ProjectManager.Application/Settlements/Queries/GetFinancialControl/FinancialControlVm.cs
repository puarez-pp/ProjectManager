using ProjectManager.Application.Settlements.Queries.GetInvoices;

namespace ProjectManager.Application.Settlements.Queries.GetFinancialControl;

public class FinancialControlVm
{
    public List<InvoiceDto> Invoices { get; set; }
    public List<InvoiceSumDto> TotalSums { get; set; }
}
