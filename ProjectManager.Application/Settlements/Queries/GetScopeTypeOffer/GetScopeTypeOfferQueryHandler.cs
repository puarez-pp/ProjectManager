using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Domain.Enums;
using System.Linq.Dynamic.Core;

namespace ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;

public class GetScopeTypeOfferQueryHandler : IRequestHandler<GetScopeTypeOfferQuery, WorkScopeTypeVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IFinanceService _financeService;

    public GetScopeTypeOfferQueryHandler(
        IApplicationDbContext context,
        IFinanceService financeService)
    {
        _context = context;
        _financeService = financeService;
    }
    public async Task<WorkScopeTypeVm> Handle(GetScopeTypeOfferQuery request, CancellationToken cancellationToken)
    {

        var margin = await _context
            .Assumptions
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id)
            .Select(x => request.ScopeType == WorkScopeType.Agregat ? x.MarginGen : x.MarginInstall)
            .FirstOrDefaultAsync(cancellationToken);


        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(s => new ProjectBasicsDto
            {
                Id = s.Id,
                Name = s.Name,
                Number = s.Number
            })
            .FirstOrDefaultAsync(cancellationToken);

        var rawScopes = await _context
            .WorkScopes
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id && x.WorkScopeType == request.ScopeType)
            .Select(s => new
            {
                s.Id,
                s.Description,
                s.Order,
                Offers = s.WorkScopeOffers.Select(y => new
                {
                    y.Id,
                    y.Description,
                    y.Order,
                    y.IsUsed,
                    y.UnitType,
                    y.Quantity,
                    y.NetAmount,
                    SubContractor = y.SubContractor.Name
                }).OrderBy(o => o.Order).ToList()
            })
            .OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);

        //Logika domenowa (ApplyMargin) wykonywana w pamięci
        var workScopes = rawScopes.Select(s => new WorkScopeDto
        {
            Id = s.Id,
            Description = s.Description,
            Order = s.Order,

            Offers = s.Offers.Select(o => new WorkScopeOfferDto
            {
                Id = o.Id,
                Description = o.Description,
                Order = o.Order,
                IsUsed = o.IsUsed,
                UnitType = o.UnitType,
                Quantity = o.Quantity,
                NetAmount = o.NetAmount,
                Total = _financeService.ApplyMargin(o.Quantity * o.NetAmount, margin),
                SubContractor = o.SubContractor
            }).ToList(),

            Total = s.Offers.Sum(o => _financeService.ApplyMargin(o.Quantity * o.NetAmount, margin))
        })
        .OrderBy(x => x.Order)
        .ToList();

        var vm = new WorkScopeTypeVm
        {
            Project = project,
            WorkScopeType = request.ScopeType,
            Margin = margin,
            Total = workScopes.Sum(x => x.Total),
            WorkScopes = workScopes
        };

        return vm;
    }

}
