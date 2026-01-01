using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.SubContractors.GetSubContractorBasics;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.SubContractors.Extension;

namespace ProjectManager.Application.SubContractors.Queries.GetSubContractorBasics;

public class GetSubContractorBasicsQueryHandler : IRequestHandler<GetSubContractorBasicsQuery, IEnumerable<SubContractorBasicsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetSubContractorBasicsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SubContractorBasicsDto>> Handle(GetSubContractorBasicsQuery request, CancellationToken cancellationToken)
    {
        var subContractors = (await _context
            .SubContractors
            .AsNoTracking()
            .ToListAsync())
            .Select(x => x.ToSubContractorBasicsDto());

        return subContractors;
    }
}
