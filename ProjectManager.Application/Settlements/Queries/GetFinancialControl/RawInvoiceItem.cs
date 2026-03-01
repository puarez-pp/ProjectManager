namespace ProjectManager.Application.Settlements.Queries.GetFinancialControl;

public class RawInvoiceItem
{
    public int Id { get; init; }
    public string Number { get; init; } = "";
    public DateTime IssueDate { get; init; }
    public decimal NetAmount { get; init; }
    public decimal EuroNetAmount { get; init; }
    public decimal EuroRate { get; init; }
    public string OrderNumber { get; init; }
    public string Vendor { get; init; } = "";
    public string ScopeDescription { get; init; } = "";
}
