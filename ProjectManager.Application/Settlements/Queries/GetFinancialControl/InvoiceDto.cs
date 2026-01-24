using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Queries.GetInvoices;

public class InvoiceDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime IssueDate { get; set; }
    public decimal NetAmount { get; set; }
    public decimal EuroNetAmount { get; set; }
    public decimal EuroRate { get; set; }
    public string Vendor { get; set; }
    public string ScopeDescription { get; set; }
    public string OrderNumber { get; set; }
}
