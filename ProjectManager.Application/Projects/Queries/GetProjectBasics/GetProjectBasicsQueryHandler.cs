using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Projects.Queries.GetProjectBasics;

public class GetProjectBasicsQueryHandler : IRequestHandler<GetProjectBasicsQuery, IEnumerable<ProjectBasicsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProjectBasicsQueryHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProjectBasicsDto>> Handle(GetProjectBasicsQuery request, CancellationToken cancellationToken)
    {
        return await _context
        .Projects
        .AsNoTracking()
        .OrderByDescending(x => x.EditAt)
        .ProjectTo<ProjectBasicsDto>(_mapper.ConfigurationProvider)
        .Take(4)
        .ToListAsync(cancellationToken);
    }
}
