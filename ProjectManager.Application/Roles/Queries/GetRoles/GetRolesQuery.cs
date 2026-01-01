using MediatR;

namespace ProjectManager.Application.Roles.Queries.GetRoles;
public class GetRolesQuery : IRequest<IEnumerable<RoleDto>>
{
}
