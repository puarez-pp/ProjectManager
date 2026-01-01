using MediatR;
using ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;

namespace ProjectManager.Application.SubContractors.GetSubContractorBasics;
public class GetSubContractorBasicsQuery : IRequest<IEnumerable<SubContractorBasicsDto>>
{
}
