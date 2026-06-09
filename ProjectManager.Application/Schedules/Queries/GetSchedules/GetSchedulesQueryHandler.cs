using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Schedules.Queries.Dto;

namespace ProjectManager.Application.Schedules.Queries.GetSchedules;

public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, SchedulesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSchedulesQueryHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<SchedulesVm> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .Include(x=>x.Schedules)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (project == null)
        {
            return null;
        }

        var vm = new SchedulesVm
        {
            Project = _mapper.Map<ProjectBasicsDto>(project),
            Schedules = _mapper.Map<IList<ScheduleDto>>(project.Schedules)
        };
        return vm;
    }
}
