using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Users.Extensions;

namespace ProjectManager.Application.Users.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;

    public GetUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context
            .Users
            .Include(x => x.Employee)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId);
        

        return user.ToUserDto();



    }
}
