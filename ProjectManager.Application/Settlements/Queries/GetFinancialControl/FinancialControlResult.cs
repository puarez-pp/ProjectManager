using ProjectManager.Application.Settlements.Queries.GetInvoices;

namespace ProjectManager.Application.Settlements.Queries.GetFinancialControl;

public class FinancialControlResult
{
    public IReadOnlyCollection<InvoiceSumDto> TotalSums { get; init; } = new List<InvoiceSumDto>();
    public IReadOnlyCollection<InvoiceDto> Invoices { get; init; } = new List<InvoiceDto>();
    public decimal TotalSum { get; init; }
}
