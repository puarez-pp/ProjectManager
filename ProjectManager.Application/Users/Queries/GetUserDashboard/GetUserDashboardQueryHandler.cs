using ProjectManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Users.Queries.GetClientDashboard;
public class GetUserDashboardQueryHandler : IRequestHandler<GetUserDashboardQuery, GetUserDashboardVm>
{
    private readonly IApplicationDbContext _context;

    public GetUserDashboardQueryHandler(
        IApplicationDbContext context
        )
    {
        _context = context;
    }

    public async Task<GetUserDashboardVm> Handle(GetUserDashboardQuery request, CancellationToken cancellationToken)
    {
        var user = await _context
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId);
        var vm = new GetUserDashboardVm
        {
            Email = user.Email
        };
        return vm;
    }

    
}
