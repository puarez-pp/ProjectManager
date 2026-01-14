using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Plants.Extension;

namespace ProjectManager.Application.Plants.Queries.GetPlantsBasic;

public class GetPlantsBasicQueryHandler : IRequestHandler<GetPlantsBasicQuery, IEnumerable<GetPlantsBasicDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPlantsBasicQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<GetPlantsBasicDto>> Handle(GetPlantsBasicQuery request, CancellationToken cancellationToken)
    {
        var plants = await _context
            .Plants
            .AsNoTracking()
            .Select(plants => plants.ToPlantsBasicDto())
            .ToListAsync(cancellationToken);
        return plants;
    }
}
