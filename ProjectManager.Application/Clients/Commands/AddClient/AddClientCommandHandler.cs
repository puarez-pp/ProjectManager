using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

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
        var client = new Client();
        client.Name = request.Name;
        client.ContactPerson = request.ContactPerson;
        client.Email = request.Email;
        client.PhoneNumber = request.PhoneNumber;
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync(cancellationToken);
        var clientid = client.Id;

        client.Address = new Address
        {
            ClientId = clientid,
            City = request.City,
            Street = request.Street,
            StreetNumber = request.StreetNumber,
            ZipCode = request.ZipCode
        };
        await _context.Addresses.AddAsync(client.Address);
        await _context.SaveChangesAsync(cancellationToken);


        return Unit.Value;
        
    }
}
