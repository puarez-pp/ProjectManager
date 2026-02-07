namespace ProjectManager.Domain.Entities;

public class Invoice
{
    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime IssueDate { get; set; }
    public decimal NetAmount { get; set; }
    public decimal EuroNetAmount { get; set; }
    public decimal EuroRate { get; set; }
    public int SettlementId { get; set; }
    public Settlement Settlement { get; set; }
    public string Vendor { get; set; }
    public int WorkScopeId { get; set; }
    public WorkScope WorkScope { get; set; }

    public string OrderNumber { get; set; }
}