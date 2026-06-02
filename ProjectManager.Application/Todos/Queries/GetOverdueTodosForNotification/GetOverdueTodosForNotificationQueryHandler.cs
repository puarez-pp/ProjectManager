using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Todos.Queries.GetOverdueTodosForNotification;

public class GetOverdueTodosForNotificationQueryHandler : IRequestHandler<GetOverdueTodosForNotificationQuery, List<OverdueTodoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public GetOverdueTodosForNotificationQueryHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }
    public async Task<List<OverdueTodoDto>> Handle(GetOverdueTodosForNotificationQuery request, CancellationToken cancellationToken)
    {
        var todos = await _context
            .Todos
            .AsNoTracking()
            .Where(t => !t.IsCompleted && t.CompletionDate != null && t.CompletionDate < _dateTimeService.Now)
            .Select(t => new OverdueTodoDto
            {
                Id = t.Id,
                Title = t.Title,
                FinishDate = t.FinishDate,
                UserToId = t.UserToId,
                UserToEmail = t.UserTo.Email
            })
            .ToListAsync(cancellationToken);
        return todos;
    }
}
