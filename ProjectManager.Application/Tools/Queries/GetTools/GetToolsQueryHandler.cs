using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Tools.Extensions;

namespace ProjectManager.Application.Tools.Queries.GetTools;

public class GetToolsQueryHandler : IRequestHandler<GetToolsQuery, List<ToolDto>>
{
    private readonly IApplicationDbContext _context;

    public GetToolsQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<ToolDto>> Handle(GetToolsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tools
            .AsNoTracking()
            .Select(tool => tool.ToToolDto())
            .ToListAsync(cancellationToken);
    }
}
