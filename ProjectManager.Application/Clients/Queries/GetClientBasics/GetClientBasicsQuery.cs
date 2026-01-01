using MediatR;

namespace ProjectManager.Application.Clients.Queries.GetClientBasics;
public class GetClientBasicsQuery : IRequest<IEnumerable<ClientBasicsDto>>
{
}
