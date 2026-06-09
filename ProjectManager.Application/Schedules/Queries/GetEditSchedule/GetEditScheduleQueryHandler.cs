
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Schedules.Commands.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetEditSchedule;

public class GetEditScheduleQueryHandler : IRequestHandler<GetEditScheduleQuery, ScheduleEditDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEditScheduleQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ScheduleEditDto> Handle(GetEditScheduleQuery request, CancellationToken cancellationToken)
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

        return _mapper.Map<ScheduleEditDto>(schedule);
    }
}