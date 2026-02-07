using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Settlements.Commands.DeleteInvoice;

public class DeleteInvoiceQueryHandler : IRequestHandler<DeleteInvoiceQuery>
{
    private readonly IApplicationDbContext _context;

    public DeleteInvoiceQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteInvoiceQuery request, CancellationToken cancellationToken)
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
