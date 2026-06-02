using MediatR;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Todos.Commands.CreateTodoNotificationLog;

public class CreateTodoNotificationLogCommand : IRequest
{
    public int TodoId { get; set; }
    public NotificationChannel Channel { get; set; }
}
