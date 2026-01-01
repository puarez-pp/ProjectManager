using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {

        var client = await _context.Clients
             .AsNoTracking()
             .Include(x=>x.Address)
             .FirstOrDefaultAsync(x=>x.Id == request.Id);
        if (client != null)
        {
            _context.Addresses.Remove(client.Address);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
