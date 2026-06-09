using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Tools.Queries.GetTools;

public class GetToolsQueryHandler : IRequestHandler<GetToolsQuery, List<ToolDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetToolsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ToolDto>> Handle(GetToolsQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Tools
            .AsNoTracking()
            .ProjectTo<ToolDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
