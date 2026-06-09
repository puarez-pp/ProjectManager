using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Clients.Queries.GetClientBasics;

public class GetClientBasicsQueryHandler : IRequestHandler<GetClientBasicsQuery, IEnumerable<ClientBasicsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClientBasicsQueryHandler(IApplicationDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientBasicsDto>> Handle(GetClientBasicsQuery request, CancellationToken cancellationToken)
    {
        return await _context
        .Clients
        .AsNoTracking()
        .OrderBy(x => x.Name)
        .ProjectTo<ClientBasicsDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
    }
}
