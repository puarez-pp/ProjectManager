using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Tools.Queries.GetRents;

public class GetRentsQueryHandler : IRequestHandler<GetRentsQuery, List<ToolRentsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ToolRentsDto>> Handle(GetRentsQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Rents
            .AsNoTracking()
            .Where(x => x.ToolId == request.Id)
            .OrderByDescending(x => x.RentDate)
            .ProjectTo<ToolRentsDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

}
