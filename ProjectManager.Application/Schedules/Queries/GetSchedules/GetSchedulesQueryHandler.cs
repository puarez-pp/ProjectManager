using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Schedules.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedules;

public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, IEnumerable<ScheduleBasicsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetSchedulesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ScheduleBasicsDto>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Schedules
            .Where(x => x.ProjectId == request.ProjectId)
            .Select(x => new ScheduleBasicsDto
            {
                Id = x.Id,
                ProjectId = x.ProjectId,
                Name = x.Name,
            }).ToListAsync(cancellationToken);
    }
}
