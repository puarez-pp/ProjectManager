using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.SubContractors.Extension;

namespace ProjectManager.Application.Projects.Queries.GetEditPosition;

public class GetEditPositionQueryHandler : IRequestHandler<GetEditPositionQuery, EditPositionVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditPositionQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditPositionVm> Handle(GetEditPositionQuery request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .Include(x => x.Client)
            .Include(x => x.User)
            .ThenInclude(x => x.Employee)
            .Include(x => x.Divisions)
            .ThenInclude(x=>x.Positions)
            .FirstOrDefaultAsync(x => x.Divisions.Any(y => y.Positions.Any(x => x.Id == request.Id)));
            

        var vm = new EditPositionVm();
        
        vm.Project = project.ToBasicsProjectDto();

         vm.DivisionType = project.Divisions
            .Where(x => x.Positions.Any(y => y.Id == request.Id))
            .Select(x => x.DivisionType)
            .FirstOrDefault();


        vm.Position = (await _context
            .DivisionPositions
            .Include(x=>x.SubContractor)
            .FirstOrDefaultAsync(x=>x.Id == request.Id))
            .ToEditPositionCommand();


        vm.AvaiableSubContractors = await _context
            .SubContractors
            .AsNoTracking()
            .Select(x => x.ToSubContractorBasicsDto())
            .ToListAsync();

        return vm;
    }
}
