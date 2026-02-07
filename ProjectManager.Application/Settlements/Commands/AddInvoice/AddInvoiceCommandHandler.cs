using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Commands.AddInvoice;

public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand>
{
    private readonly IApplicationDbContext _context;

    public AddInvoiceCommandHandler(
        IApplicationDbContext context)
    {
        this._context = context;
    }
    public async Task<Unit> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = new Invoice
        {
            Number = request.Number,
            IssueDate = request.IssueDate,
            WorkScopeId = request.WorkScopeId,
            NetAmount = request.NetAmount,
            EuroNetAmount = request.EuroNetAmount,
            EuroRate = request.EuroRate,
            Vendor = request.Vendor,
            OrderNumber = request.OrderNumber,
        };
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
