using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Commands.AddInvoice;
using ProjectManager.Application.Settlements.Queries.GetAssumption;

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
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(x => new ProjectBasicsDto
            {
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
            })
            .FirstOrDefaultAsync(cancellationToken);

        var settlement = await _context
            .Settlements
            .AsNoTracking()
            .Where(x => x.ProjectId == request.Id)
            .Select(x => new SettlementDto
            {
                Id = x.Id,
                WorkScopes = x.WorkScopes
                .Select(w => new WorkScopeDto
                {
                    Id = w.Id,
                    Description = w.Description,
                    WorkScopeType = w.WorkScopeType,
                    Order = w.Order,
                }).OrderBy(x => x.Order)
                .ToList(),
                CreatedAt = x.CreatedAt,
            })
            .FirstOrDefaultAsync();

        return new AddInvoiceVm
        {
            Project = project,
            Settlement = settlement,
            Invoice = new AddInvoiceCommand
            {
                IssueDate = DateTime.Now,
            }
        };
    }
}
