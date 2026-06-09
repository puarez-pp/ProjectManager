using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Projects.Queries.GetScopes;

public class GetScopeQueryHandler : IRequestHandler<GetScopeQuery, ProjectScopeDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetScopeQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProjectScopeDto> Handle(GetScopeQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .ProjectScopes
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<ProjectScopeDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);
    }
}
