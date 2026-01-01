using ProjectManager.Application.Clients.Commands.EditClient;
using ProjectManager.Application.Clients.Queries.GetClientBasics;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Clients.Extension;

public static class ClientExtension
{
    public static ClientBasicsDto ToClientBasicsDto(this Client client)
    {
        if (client == null)
            return null;

        return new ClientBasicsDto
        {
            Id = client.Id,
            Email = client.Email,
            Name = client.Name,
            ContactPerson = client.ContactPerson,
        };
    }

    public static EditClientCommand ToEditClientCommand(this Client client)
    {
        if (client == null)
            return null;
        return new EditClientCommand
        {
            Id= client.Id,
            Name = client.Name,
            ContactPerson = client.ContactPerson,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            City = client.Address.City,
            Street = client.Address.Street,
            StreetNumber = client.Address.StreetNumber,
            ZipCode = client.Address.ZipCode
        };
    }
}
 