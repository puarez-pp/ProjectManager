using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using MediatR;


namespace ProjectManager.Application.EmployeeEvents.Commands.AddEmployeeEvent;
public class AddEmployeeEventCommandHandler : IRequestHandler<AddEmployeeEventCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public AddEmployeeEventCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    public async Task<Unit> Handle(AddEmployeeEventCommand request, CancellationToken cancellationToken)
    {
        if (request.IsFullDay.GetValueOrDefault())
            request.End = null;

        var employeeEvent = new EmployeeEvent
        {
            End = request.End,
            IsFullDay = request.IsFullDay.GetValueOrDefault(),
            Start = request.Start,
            UserId = request.UserId,
            CreatedDate = _dateTimeService.Now
        };

        _context.EmployeeEvents.Add(employeeEvent);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
