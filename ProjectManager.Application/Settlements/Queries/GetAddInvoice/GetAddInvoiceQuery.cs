using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetAddInvoice;

public class GetAddInvoiceQuery : IRequest<AddInvoiceVm>
{
    public int Id { get; set; }
}
