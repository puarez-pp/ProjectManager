using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Tools.Extensions;

namespace ProjectManager.Application.Tools.Queries.GetRents;

public class GetRentsQueryHandler : IRequestHandler<GetRentsQuery, List<ToolRentsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRentsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<ToolRentsDto>> Handle(GetRentsQuery request, CancellationToken cancellationToken)
    {
        var rents = await _context
            .Rents
            .AsNoTracking ()
            .Where(x => x.ToolId == request.Id)
            .OrderByDescending(x => x.RentDate)
            .Select(x=>new ToolRentsDto
            {
                Id = x.Id,
                User = $"{x.User.FirstName} {x.User.LastName}",
                RentDate = x.RentDate,
                ReturnDate = x.ReturnDate,
            })
            .ToListAsync(cancellationToken);
        return rents;
    }
}
