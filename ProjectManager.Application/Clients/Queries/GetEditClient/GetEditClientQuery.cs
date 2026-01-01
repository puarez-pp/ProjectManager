using MediatR;
using ProjectManager.Application.Clients.Commands.EditClient;

namespace ProjectManager.Application.Clients.Queries.GetEditClient;

public class GetEditClientQuery:IRequest<EditClientCommand>
{
    public int Id { get; set; }
}
