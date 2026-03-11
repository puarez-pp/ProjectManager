using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Schedules.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedule;

public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, ScheduleDto>
{
    private readonly IApplicationDbContext _context;

    public GetScheduleQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ScheduleDto> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
    {
        return await _context
           .Schedules
           .Where(x => x.Id == request.Id)
           .Select(x => new ScheduleDto
           {
               Id = x.Id,
               ProjectId = x.ProjectId,
               Name = x.Name,
               Comment = x.Comment,
               Stages = x.Stages.Select(s => new StageDto
               {
                   Id = s.Id,
                   Name = s.Name,
                   PlannedStart = s.PlannedStart,
                   PlannedEnd = s.PlannedEnd,
                   Tasks = s.Tasks.Select(t => new TaskDto
                   {
                       Id = t.Id,
                       Name = t.Name,
                       Status = t.Status,
                       PlannedStart = t.PlannedStart,
                       PlannedEnd = t.PlannedEnd
                   }).ToList()
               }).ToList()
           })
           .FirstOrDefaultAsync(cancellationToken);
    }
}
