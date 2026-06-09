using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Todos.Queries.GetProjectTodos;

namespace ProjectManager.Application.Todos.Queries.GetTodo;

public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, TodoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<TodoDto> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        return await _context
        .Todos
        .AsNoTracking()
        .Where(x => x.Id == request.Id)
        .ProjectTo<TodoDto>(_mapper.ConfigurationProvider)
        .FirstOrDefaultAsync(cancellationToken);
    }
}
