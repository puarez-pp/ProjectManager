using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Tools.Queries.GetUserRents;

public class GetUserRentsQueryHandler : IRequestHandler<GetUserRentsQuery, List<UserRentsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetUserRentsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<UserRentsDto>> Handle(GetUserRentsQuery request, CancellationToken cancellationToken)
    {
        return await _context
                .Rents
                .AsNoTracking()
                .OrderByDescending(x => x.RentDate)
                .Where(x => x.UserId == request.UserId)
                .OrderByDescending (x => x.RentDate)
                .Select(x => new UserRentsDto
                {
                    Id = x.Id,
                    ToolName = x.Tool.Name,
                    RentDate = x.RentDate,
                    ReturnDate = x.ReturnDate == null ? null : x.ReturnDate
                })
                .ToListAsync(cancellationToken);
    }
}
