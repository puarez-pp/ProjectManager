using MediatR;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Clients.Commands.AddClient;
public class AddClientCommandHandler : IRequestHandler<AddClientCommand>
{
    private readonly IApplicationDbContext _context;

    public AddClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Domain.Entities.Client();
        client.Name = request.Name;
        client.ContactPerson = request.ContactPerson;
        client.Email = request.Email;
        client.PhoneNumber = request.PhoneNumber;
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync(cancellationToken);
        var clientid = client.Id;

        client.Address = new Domain.Entities.Address();
        client.Address.ClientId = clientid;
        client.Address.City = request.City;
        client.Address.Street = request.Street;
        client.Address.StreetNumber = request.StreetNumber;
        client.Address.ZipCode = request.ZipCode;
        await _context.Addresses.AddAsync(client.Address);
        await _context.SaveChangesAsync(cancellationToken);


        return Unit.Value;
        
    }
}
