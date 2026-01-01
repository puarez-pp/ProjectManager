using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Users.Commands.EditUser;
public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
{
    private readonly IApplicationDbContext _context;


    public EditUserCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.PhoneNumber = request.PhoneNumber;

        if (user.Employee == null)
            user.Employee = new Domain.Entities.Employee();

        user.Employee.UserId = request.Id;

        user.Employee.ImageUrl = request.ImageUrl;
 
        user.Employee.Position = (Position)request.PositionId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
