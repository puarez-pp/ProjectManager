using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;

namespace ProjectManager.Application.Projects.Queries.GetPosition;

public class GetPositionQueryHandler : IRequestHandler<GetPositionQuery, GetPositiontVm>
{
    private readonly IApplicationDbContext _context;

    public GetPositionQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetPositiontVm> Handle(GetPositionQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
           .Projects
           .Include(x => x.Client)
           .Include(x => x.User)
           .ThenInclude(x => x.Employee)
           .Include(x => x.Divisions)
           .ThenInclude(x=>x.Positions)
           .AsNoTracking()
           .FirstOrDefaultAsync(x => x.Divisions.Any(y => y.Positions.Any(x => x.Id == request.Id)));

        var vm = new GetPositiontVm();

        vm.Project = project.ToBasicsProjectDto();

        vm.DivisionType = project.Divisions
            .Where(x => x.Positions.Any(y => y.Id == request.Id))
            .Select(x => x.DivisionType)
            .FirstOrDefault();

        vm.Position = (await _context
            .DivisionPositions
            .Include(x=>x.SubContractor)
            .Include(x=>x.PositionPosts)
            .ThenInclude(x=>x.User)
            .ThenInclude(x=>x.Employee)
            .FirstOrDefaultAsync(x => x.Id == request.Id))
            .ToPositionDto();

        return vm;
    }
}
