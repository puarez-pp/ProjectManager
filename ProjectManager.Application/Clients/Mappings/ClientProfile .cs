using AutoMapper;
using ProjectManager.Application.Clients.Queries.GetClientBasics;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Clients.Mappings;

public class ClientProfile: Profile  
{
    public ClientProfile()
    {
        CreateMap<Client, ClientBasicsDto>();
    }
}
