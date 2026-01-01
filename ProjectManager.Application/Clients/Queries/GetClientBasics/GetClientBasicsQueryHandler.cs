using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Clients.Extension;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Clients.Queries.GetClientBasics;

public class GetClientBasicsQueryHandler : IRequestHandler<GetClientBasicsQuery, IEnumerable<ClientBasicsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetClientBasicsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClientBasicsDto>> Handle(GetClientBasicsQuery request, CancellationToken cancellationToken)
    {
        var clients = (await _context.Clients
            .AsNoTracking()
            .ToListAsync())
            .Select(x => x.ToClientBasicsDto());

        return clients;
    }
}
