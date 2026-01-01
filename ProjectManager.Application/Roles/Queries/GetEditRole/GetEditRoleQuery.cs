using ProjectManager.Application.Roles.Commands.EditRole;
using MediatR;


namespace ProjectManager.Application.Roles.Queries.GetEditRole;
public class GetEditRoleQuery : IRequest<EditRoleCommand>
{
    public string Id { get; set; }
}
