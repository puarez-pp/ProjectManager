using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Schedules.Queries.GetScheduleDetails;

namespace ProjectManager.Application.Schedules.Queries.GetSchedules;

public class GetScheduleDetailsQueryHandler : IRequestHandler<GetScheduleDetailsQuery, ScheduleDetailsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICriticalPathService _cpm;

    public GetScheduleDetailsQueryHandler(IApplicationDbContext context,
        IMapper mapper,
        ICriticalPathService cpm)
    {
        _context = context;
        _mapper = mapper;
        _cpm = cpm;
    }

    public async Task<ScheduleDetailsVm> Handle(GetScheduleDetailsQuery request, CancellationToken cancellationToken)
    {
        var schedule = await _context.Schedules
            .Include(s => s.Stages)
                .ThenInclude(st => st.Tasks)
                    .ThenInclude(t => t.Dependencies)
            .Include(s => s.Stages)
                .ThenInclude(st => st.Tasks)
                    .ThenInclude(t => t.Predecessors)
            .Include(s => s.Stages)
                .ThenInclude(st => st.Tasks)
                    .ThenInclude(t => t.AssignedUser)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (schedule == null)
            throw new KeyNotFoundException($"Schedule {request.Id} not found.");

        var vm = _mapper.Map<ScheduleDetailsVm>(schedule);

        var tasks = schedule.Stages.SelectMany(s => s.Tasks).ToList();
        vm.CriticalPath = _cpm.CalculateDetailedCriticalPathDto(tasks);

        return vm;
    }
}
