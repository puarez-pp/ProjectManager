namespace ProjectManager.Application.Settlements.Queries.GetFinancialControl;

public class RawFinancialControlScope
{
    public int Id { get; init; }
    public string Description { get; init; } = "";
    public int Order { get; init; }
    public IReadOnlyCollection<RawInvoiceItem> Invoices { get; init; } = new List<RawInvoiceItem>();
}
