using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Users.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Users.Queries.GetEditUser;
public class GetEditUserQueryHandler : IRequestHandler<GetEditUserQuery, EditUserVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IRoleManagerService _roleManagerService;
    private readonly IUserRoleManagerService _userRoleManagerService;

    public GetEditUserQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;

    }

    public async Task<EditUserVm> Handle(GetEditUserQuery request, CancellationToken cancellationToken)
    {
        var vm = new EditUserVm();

        vm.User = (await _context
            .Users
            .Include(x => x.Employee)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId))
            .ToEditUser();


        if (!string.IsNullOrWhiteSpace(vm.User.ImageUrl))
            vm.UserFullPathImage = $"/Content/Files/{vm.User.ImageUrl}";

        return vm;
    }
}
