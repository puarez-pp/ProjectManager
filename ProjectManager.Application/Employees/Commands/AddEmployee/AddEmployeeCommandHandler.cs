using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;
using ProjectManager.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Application.Employees.Commands.AddEmployee;
public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserManagerService _userManagerService;
    private readonly IDateTimeService _dateTimeService;

    public AddEmployeeCommandHandler(
        IApplicationDbContext context,
        IUserManagerService userManagerService,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _userManagerService = userManagerService;
        _dateTimeService = dateTimeService;
    }

    public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var userId = await _userManagerService.CreateAsync(request.Email, request.Password, RolesDict.Pracownik);

        var user = await _context.Users
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == userId);

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.RegisterDateTime = _dateTimeService.Now;
        user.EmailConfirmed = false;

        user.Employee = new Domain.Entities.Employee();
        user.Employee.UserId = userId;
        user.Employee.ImageUrl = request.ImageUrl;
        user.Employee.Position = (Position)request.PositionId;


        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
