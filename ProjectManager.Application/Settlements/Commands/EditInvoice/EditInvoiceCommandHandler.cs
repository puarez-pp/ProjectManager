using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Commands.EditInvoice;

public class EditInvoiceCommandHandler : IRequestHandler<EditInvoiceCommand>
{
    private readonly IApplicationDbContext _context;

    public EditInvoiceCommandHandler(
        IApplicationDbContext context)

    {
        _context = context;
    }        
    public async Task<Unit> Handle(EditInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _context
            .Invoices
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (invoice != null) 
        {
            invoice.Number = request.Number;
            invoice.IssueDate = request.IssueDate;
            invoice.WorkScopeId = request.WorkScopeId;
            invoice.NetAmount = request.NetAmount;
            invoice.EuroNetAmount = request.EuroNetAmount;
            invoice.EuroRate = request.EuroRate;
            invoice.Vendor = request.Vendor;
            invoice.OrderNumber = request.OrderNumber;
            await _context.SaveChangesAsync();
        }

        return Unit.Value;
    }
}
