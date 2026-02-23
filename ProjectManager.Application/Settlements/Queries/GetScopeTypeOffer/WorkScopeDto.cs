using ProjectManager.Application.Settlements.Queries.GetInvoices;
using ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;
using ProjectManager.Domain.Enums;
public class WorkScopeDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public WorkScopeType WorkScopeType { get; set; }
    public int Order { get; set; }
    public decimal Total { get; set; }
    public List<WorkScopeOfferDto> Offers { get; set; } = new();
    public List<WorkScopeCostDto> Costs { get; set; } = new();
    public List<InvoiceDto> Invoices { get; set; } = new();
}