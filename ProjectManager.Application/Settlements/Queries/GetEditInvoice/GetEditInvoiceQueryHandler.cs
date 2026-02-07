using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.AddInvoice;
using ProjectManager.Application.Settlements.Commands.EditInvoice;
using ProjectManager.Application.Settlements.Queries.GetAddInvoice;

namespace ProjectManager.Application.Settlements.Queries.GetEditInvoice;

public class GetEditInvoiceQueryHandler : IRequestHandler<GetEditInvoiceQuery, EditInvoiceVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditInvoiceQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditInvoiceVm> Handle(GetEditInvoiceQuery request, CancellationToken cancellationToken)
    {

        var scopes = await _context
        .WorkScopes
        .Where(x => x.SettlementId == request.Id)
        .Select(x => new WorkScopeDto
        {
            Id = x.Id,
            Description = x.Description,
        })
        .OrderBy(x => x.Order)
        .ToListAsync();

        var invoice = await _context
            .Invoices
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return new EditInvoiceVm
        {
            WorkScopes = scopes,
            Invoice = new EditInvoiceCommand 
            { 
                Id = request.Id,
                WorkScopeId = invoice.Id,
                Number = invoice.Number,
                IssueDate = invoice.IssueDate,
                NetAmount = invoice.NetAmount,
                EuroNetAmount = invoice.EuroNetAmount,
                EuroRate = invoice.EuroRate,
                Vendor = invoice.Vendor,
                OrderNumber = invoice.OrderNumber,
            }
        };
    }
}
