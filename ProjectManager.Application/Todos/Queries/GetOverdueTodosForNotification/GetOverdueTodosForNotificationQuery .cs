using MediatR;

namespace ProjectManager.Application.Todos.Queries.GetOverdueTodosForNotification;

public class GetOverdueTodosForNotificationQuery : IRequest<List<OverdueTodoDto>>
{

}
