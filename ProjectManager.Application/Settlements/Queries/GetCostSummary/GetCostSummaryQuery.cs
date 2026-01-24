using MediatR;

namespace ProjectManager.Application.Settlements.Queries.GetCostSummary;

public class GetCostSummaryQuery : IRequest<CostSummaryVm>
{
    public int Id { get; set; }
}
