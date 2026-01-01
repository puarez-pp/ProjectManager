using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Clients.Commands.EditClient;
using ProjectManager.Application.Clients.Extension;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Clients.Queries.GetEditClient;

public class GetEditClientQueryHandler : IRequestHandler<GetEditClientQuery, EditClientCommand>
{
    private readonly IApplicationDbContext _context;
     
    public GetEditClientQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EditClientCommand> Handle(GetEditClientQuery request, CancellationToken cancellationToken)
    {
        var client = (await _context
            .Clients
            .Include(x => x.Address)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id))
            .ToEditClientCommand();
        return client;
    }
}
