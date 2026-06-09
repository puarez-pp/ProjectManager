using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProject;

namespace ProjectManager.Application.Posts.Queries.GetPositionPosts;

public class GetPositionPostsQueryHandler : IRequestHandler<GetPositionPostsQuery, List<PositionPostDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPositionPostsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<PositionPostDto>> Handle(GetPositionPostsQuery request, CancellationToken cancellationToken)
    {
        return await _context
        .PositionPosts
        .AsNoTracking()
        .Where(x => x.PositionId == request.Id)
        .OrderByDescending(x => x.CreatedAt)
        .ProjectTo<PositionPostDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);
    }
}
