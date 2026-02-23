using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Settlements.Commands.DeleteInvoice;

public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteInvoiceCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {

        var invoice = await _context
            .Invoices
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (invoice != null)
        { 
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
