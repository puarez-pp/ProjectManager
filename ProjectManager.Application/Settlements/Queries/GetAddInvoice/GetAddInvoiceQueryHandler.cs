using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.AddInvoice;
using ProjectManager.Application.Settlements.Extensions;

namespace ProjectManager.Application.Settlements.Queries.GetAddInvoice;

public class GetAddInvoiceQueryHandler : IRequestHandler<GetAddInvoiceQuery, AddInvoiceVm>
{
    private readonly IApplicationDbContext _context;

    public GetAddInvoiceQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<AddInvoiceVm> Handle(GetAddInvoiceQuery request, CancellationToken cancellationToken)
    {
        var scopes = await _context
            .WorkScopes
            .Where(x => x.SettlementId == request.Id)
            .Select(x => new WorkScopeDto
            {
                Id = x.Id,
                Description = x.Description,
            })
            .OrderBy(x=> x.Order)
            .ToListAsync();

        return new AddInvoiceVm
        {
            WorkScopes = scopes,
            Invoice = new AddInvoiceCommand { WorkScopeId = request.Id }
        };
    }
}
