using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetTodoPosts;

public class GetTodoPostsQueryHandler : IRequestHandler<GetTodoPostsQuery, List<TodoPostDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoPostsQueryHandler(
        IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<TodoPostDto>> Handle(GetTodoPostsQuery request, CancellationToken cancellationToken)
    {

        return await _context
            .TodoPosts
            .AsNoTracking()
            .Where(x => x.TodoId == request.Id)
            .OrderByDescending(p => p.CreatedAt)
            .ProjectTo<TodoPostDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
