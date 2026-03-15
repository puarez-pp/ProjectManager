using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Schedules.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedules;

public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, List<ScheduleDto>>
{
    private readonly IApplicationDbContext _context;

    public GetSchedulesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ScheduleDto>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Schedules
            .Where(s => s.ProjectId == request.ProjectId)
            .OrderByDescending(s => s.CreatedAt)
            .Select(s => new ScheduleDto
            {
                Id = s.Id,
                Name = s.Name,
                Comment = s.Comment,
                CreatedAt = s.CreatedAt,
                EditAt = s.EditAt,
                UserName = $"{s.User.FirstName} {s.User.LastName}",
                StagesCount = s.Stages.Count(),
                TasksCount = s.Stages.SelectMany(s => s.Tasks).Count()
            })
            .ToListAsync(cancellationToken);
    }
}
