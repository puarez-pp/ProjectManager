using MediatR;

namespace ProjectManager.Application.Settlements.Commands.DeleteInvoice;

public class DeleteInvoiceQuery : IRequest
{
    public int Id { get; set; }
}
