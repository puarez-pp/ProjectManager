using MediatR;

namespace ProjectManager.Application.Users.Queries.GetUser;

public class GetUserQuery:IRequest<UserDto>
{
    public string UserId { get; set; }
}
