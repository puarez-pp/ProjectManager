using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetEditInvoice;

public class GetEditInvoiceQuery : IRequest<EditInvoiceVm>
{
    public int Id { get; set; }
}
