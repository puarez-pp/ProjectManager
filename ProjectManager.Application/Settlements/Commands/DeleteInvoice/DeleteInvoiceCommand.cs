using MediatR;

namespace ProjectManager.Application.Settlements.Commands.DeleteInvoice;

public class DeleteInvoiceCommand : IRequest
{
    public int Id { get; set; }
}
