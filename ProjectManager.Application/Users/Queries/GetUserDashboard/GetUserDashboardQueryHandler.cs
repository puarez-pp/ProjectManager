using ProjectManager.Application.Charts.Queries.Dtos;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Users.Queries.GetClientDashboard;
public class GetUserDashboardQueryHandler : IRequestHandler<GetUserDashboardQuery, GetUserDashboardVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public GetUserDashboardQueryHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    public async Task<GetUserDashboardVm> Handle(GetUserDashboardQuery request, CancellationToken cancellationToken)
    {
        var vm = new GetUserDashboardVm();
        
        return vm;
    }

    
}
