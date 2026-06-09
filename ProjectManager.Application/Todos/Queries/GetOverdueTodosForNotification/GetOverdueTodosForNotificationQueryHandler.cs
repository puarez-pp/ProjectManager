using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Todos.Queries.GetOverdueTodosForNotification;

public class GetOverdueTodosForNotificationQueryHandler : IRequestHandler<GetOverdueTodosForNotificationQuery, List<OverdueTodoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly IMapper _mapper;

    public GetOverdueTodosForNotificationQueryHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService,
        IMapper mapper)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _mapper = mapper;
    }
    public async Task<List<OverdueTodoDto>> Handle(GetOverdueTodosForNotificationQuery request, CancellationToken cancellationToken)
    {
        return await _context
        .Todos
        .AsNoTracking()
        .Where(t => !t.IsCompleted
                 && t.FinishDate != null
                 && t.FinishDate < _dateTimeService.Now)
        .ProjectTo<OverdueTodoDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
    }
}
