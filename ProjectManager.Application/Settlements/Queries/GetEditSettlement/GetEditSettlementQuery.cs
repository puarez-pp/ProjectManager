using MediatR;
using ProjectManager.Application.Settlements.Commands.EditSettlement;

namespace ProjectManager.Application.Settlements.Queries.GetEditSettlement;

public class GetEditSettlementQuery : IRequest<EditSettlementCommand>
{
    public int Id { get; set; }
}
