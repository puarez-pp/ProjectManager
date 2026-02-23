using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Commands.EditInvoice;
using ProjectManager.Application.Settlements.Queries.GetAssumption;

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
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(x => x.Settlement.WorkScopes.Any(x => x.Invoices.Any(i => i.Id == request.Id)))
            .Select(x => new ProjectBasicsDto
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
            })
            .FirstOrDefaultAsync(cancellationToken);

        var settlement = await _context
            .Settlements
            .Where(x => x.WorkScopes.Any(y => y.Invoices.Any(i => i.Id == request.Id)))
            .Select(s => new SettlementDto
            {
                Id = s.Id,
                WorkScopes = s.WorkScopes
                    .Select(w => new WorkScopeDto
                    {
                        Id = w.Id,
                        Description = w.Description,
                        WorkScopeType = w.WorkScopeType,
                        Order = w.Order,
                    }).OrderBy(x => x.Order)
                    .ToList(),
            })
            .FirstOrDefaultAsync();

        var invoice = await _context
            .Invoices
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return new EditInvoiceVm
        {
            Project = project,
            Settlement = settlement,
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
