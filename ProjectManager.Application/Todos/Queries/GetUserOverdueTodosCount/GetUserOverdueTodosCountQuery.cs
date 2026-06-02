using MediatR;

namespace ProjectManager.Application.Todos.Queries.GetUserOverdueTodosCount;

public class GetUserOverdueTodosCountQuery : IRequest<int>
{
    public string UserId { get; set; }
}
