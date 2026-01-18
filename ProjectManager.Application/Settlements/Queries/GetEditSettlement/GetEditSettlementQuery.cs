using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetEditSettlement;

public class GetEditSettlementQuery : IRequest<EditSettlementVm>
{
    public int Id { get; set; }
}
