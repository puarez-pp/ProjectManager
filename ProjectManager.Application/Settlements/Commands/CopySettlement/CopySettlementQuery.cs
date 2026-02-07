using MediatR;

namespace ProjectManager.Application.Settlements.Commands.CopySettlement;

public class CopySettlementQuery : IRequest
{
    public int SourceId { get; set; }
    public int CloneId { get; set; }
}
