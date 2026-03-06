using MediatR;

namespace ProjectManager.Application.Tools.Queries.GetUserRents;

public class GetUserRentsQuery:IRequest<List<UserRentsDto>>
{
    public string UserId { get; set; }
}
