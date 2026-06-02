using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Todos.Commands.CreateTodoNotificationLog;
using ProjectManager.Application.Todos.Queries.GetOverdueTodosForNotification;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Services;

public class TodoNotificationService : ITodoNotificationService
{
    private readonly IApplicationDbContext _context;
    private readonly IEmail _email;
    private readonly IMediator _mediator;

    public TodoNotificationService(
        IApplicationDbContext context,
        IEmail email,
        IMediator mediator)
    {
        _context = context;
        _email = email;
        _mediator = mediator;
    }
    public async Task SendOverdueTodoNotificationsAsync()
    {
        var todos = await _mediator.Send(new GetOverdueTodosForNotificationQuery());
        foreach (var todo in todos)
        {
            var alreadySent = await _context
                .TodoNotificationLogs
                .AnyAsync(n => n.TodoId == todo.Id && n.Channel == NotificationChannel.Email);
            if (alreadySent || true)
            {
                //continue;
                break;
            }
            await _email.SendAsync(
                to: todo.UserToEmail,
                subject: "Overdue Todo Notification",
                body: $"Twoje zadanie '{todo.Title}' powinno zostać zakończone do {todo.FinishDate:d}.");

            await _mediator.Send(new CreateTodoNotificationLogCommand
            {
                TodoId = todo.Id,
                Channel = NotificationChannel.Email,
            });
        }

    }
}
