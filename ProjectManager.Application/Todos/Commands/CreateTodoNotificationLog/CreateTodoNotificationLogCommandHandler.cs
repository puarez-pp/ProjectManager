using MediatR;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Todos.Commands.CreateTodoNotificationLog;

public class CreateTodoNotificationLogCommandHandler : IRequestHandler<CreateTodoNotificationLogCommand>
{
    private readonly IApplicationDbContext _context;

    private readonly IDateTimeService _dateTimeService;

    public CreateTodoNotificationLogCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    } 
    public async Task<Unit> Handle(CreateTodoNotificationLogCommand request, CancellationToken cancellationToken)
    {
        var log = new Domain.Entities.TodoNotificationLog
        {
            TodoId = request.TodoId,
            Channel = request.Channel,
            CreatedAt = _dateTimeService.Now
        };
        await _context.TodoNotificationLogs.AddAsync(log, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
