using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Schedules.Queries.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public class GetScheduleCriticalPathQueryHandler : IRequestHandler<GetScheduleCriticalPathQuery, CriticalPathResultDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ICriticalPathService _cpm;

    public GetScheduleCriticalPathQueryHandler(IApplicationDbContext context,
        ICriticalPathService cpm)
    {
        _context = context;
        _cpm = cpm;
    }

    public async Task<CriticalPathResultDto> Handle(GetScheduleCriticalPathQuery request, CancellationToken cancellationToken)
    {
        var schedule = await _context.Schedules
             .Include(s => s.Stages)
                 .ThenInclude(st => st.Tasks)
                     .ThenInclude(t => t.Dependencies)
             .Include(s => s.Stages)
                 .ThenInclude(st => st.Tasks)
                     .ThenInclude(t => t.Predecessors)
             .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (schedule == null)
            throw new KeyNotFoundException($"Schedule {request.Id} not found.");

        var tasks = schedule.Stages
            .SelectMany(s => s.Tasks)
            .ToList();

        return _cpm.CalculateDetailedCriticalPathDto(tasks);
    }
}
