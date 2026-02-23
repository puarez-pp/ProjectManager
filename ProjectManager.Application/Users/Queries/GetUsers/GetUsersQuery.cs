using MediatR;
using ProjectManager.Application.Users.Queries.GetUser;

namespace ProjectManager.Application.Users.Queries.GetUsers;

public class GetUsersQuery:IRequest<IEnumerable<UserDto>>
{
}