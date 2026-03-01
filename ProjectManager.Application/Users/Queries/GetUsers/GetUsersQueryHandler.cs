using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Users.Extensions;
using ProjectManager.Application.Users.Queries.GetUser;
using System.Linq.Dynamic.Core;

namespace ProjectManager.Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    private readonly IApplicationDbContext _context;

    public GetUsersQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context
            .Users
            .Include(x => x.Employee)
            .AsNoTracking()
            .Select(x=>x.ToUserDto())
            .ToListAsync();
        return users;
    }
}
