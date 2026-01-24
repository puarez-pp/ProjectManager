using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetFinancialControl;

public class GetFinancialControlQuery : IRequest<FinancialControlVm>
{
    public int Id { get; set; }
}
