using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Tools.Extensions;

namespace ProjectManager.Application.Tools.Queries.GetUserRents;

public class GetUserRentsQueryHandler : IRequestHandler<GetUserRentsQuery, List<UserRentsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public GetUserRentsQueryHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUserService)
    {
        this._context = context;
        this._currentUserService = currentUserService;
    }
    public async Task<List<UserRentsDto>> Handle(GetUserRentsQuery request, CancellationToken cancellationToken)
    {
        return await _context
                .Rents
                .AsNoTracking()
                .OrderByDescending(x => x.RentDate)
                .Where(x => x.UserId == _currentUserService.UserId)
                .Select(x=>x.ToUserRentsDto())
                .ToListAsync(cancellationToken);
    }
}
