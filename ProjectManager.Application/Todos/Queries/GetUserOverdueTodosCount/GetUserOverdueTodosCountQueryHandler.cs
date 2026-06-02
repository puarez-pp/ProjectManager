using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Todos.Queries.GetUserOverdueTodosCount;

public class GetUserOverdueTodosCountQueryHandler : IRequestHandler<GetUserOverdueTodosCountQuery, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public GetUserOverdueTodosCountQueryHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    public async Task<int> Handle(GetUserOverdueTodosCountQuery request, CancellationToken cancellationToken)
    {
        var count = await _context
            .Todos
            .AsNoTracking()
            .Where(t => !t.IsCompleted && t.CompletionDate != null && t.CompletionDate < _dateTimeService.Now && t.UserToId == request.UserId)
            .CountAsync(cancellationToken);
        return count;
    }
}