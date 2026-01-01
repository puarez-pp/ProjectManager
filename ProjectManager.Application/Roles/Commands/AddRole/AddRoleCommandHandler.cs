using ProjectManager.Application.Common.Interfaces;
using MediatR;

namespace ProjectManager.Application.Roles.Commands.AddRole;
public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand>
{
    private readonly IRoleManagerService _roleManagerService;

    public AddRoleCommandHandler(IRoleManagerService roleManagerService)
    {
        _roleManagerService = roleManagerService;
    }

    public async Task<Unit> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleManagerService.CreateAsync(request.Name);
        return Unit.Value;
    }
}
