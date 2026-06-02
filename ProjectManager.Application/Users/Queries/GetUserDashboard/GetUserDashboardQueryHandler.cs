using ProjectManager.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Todos.Queries.GetUserOverdueTodosCount;

namespace ProjectManager.Application.Users.Queries.GetClientDashboard;
public class GetUserDashboardQueryHandler : IRequestHandler<GetUserDashboardQuery, GetUserDashboardVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMediator _mediator;

    public GetUserDashboardQueryHandler(
        IApplicationDbContext context,
        IMediator mediator
        )
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<GetUserDashboardVm> Handle(GetUserDashboardQuery request, CancellationToken cancellationToken)
    {
        var user = await _context
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId);

        var overdueTodosCount = await _mediator.Send(new GetUserOverdueTodosCountQuery { UserId = request.UserId });

        var vm = new GetUserDashboardVm
        {
            Email = user.Email,
            OverdueTodosCount = overdueTodosCount
        };
        return vm;
    }

    
}
