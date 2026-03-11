using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Schedules.Dto;
using System.Threading.Tasks;

namespace ProjectManager.Application.Schedules.CriticalPath;

public class GetCriticalPathQuery : IRequest<CriticalPathResultDto>
{
    public int ScheduleId { get; set; }
}

public class GetCriticalPathQueryHandler : IRequestHandler<GetCriticalPathQuery, CriticalPathResultDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ICriticalPathService _criticalPath;

    public GetCriticalPathQueryHandler(IApplicationDbContext context,
        ICriticalPathService criticalPath)
    {
        _context = context;
        _criticalPath = criticalPath;
    }
    public async Task<CriticalPathResultDto> Handle(GetCriticalPathQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _context
            .Schedules
            .Where(x=>x.Id == request.ScheduleId)
            .Select(x=>x.Stages.SelectMany(x=>x.Tasks))
            .FirstOrDefaultAsync(cancellationToken);

        if (!tasks.Any())
            return new CriticalPathResultDto(); 

        var result = _criticalPath.CalculateDetailedCriticalPathDto(tasks);

        return result;
    }
}
