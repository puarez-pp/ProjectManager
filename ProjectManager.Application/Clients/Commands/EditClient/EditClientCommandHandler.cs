using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Clients.Commands.EditClient;

public class EditClientCommandHandler : IRequestHandler<EditClientCommand>
{
    private readonly IApplicationDbContext _context;

    public EditClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _context
            .Clients
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        client.Name = request.Name;
        client.ContactPerson = request.ContactPerson;
        client.Email = request.Email;
        client.PhoneNumber = request.PhoneNumber;
        if (client.Address == null)
            client.Address = new Domain.Entities.Address();
        client.Address.City = request.City;
        client.Address.Street = request.Street;
        client.Address.StreetNumber = request.StreetNumber;
        client.Address.ZipCode = request.ZipCode;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
