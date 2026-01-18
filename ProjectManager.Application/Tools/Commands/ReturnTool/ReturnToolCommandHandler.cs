using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Tools.Commands.ReturnTool;

public class ReturnToolCommandHandler : IRequestHandler<ReturnToolCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeService _dateTimeService;

    public ReturnToolCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _currentUserService = currentUserService;
    }

    public ToolStatus Available { get; private set; }

    public async Task<Unit> Handle(ReturnToolCommand request, CancellationToken cancellationToken)
    {
        var rent = await _context
            .Tools
            .Include(t => t.Rents)
            .FirstOrDefaultAsync(t => t.Rents.Any(x => x.Id == request.Id), cancellationToken);
        if (rent != null)
        {
            rent.ToolStatus = Available;
            rent.Rents.FirstOrDefault(x => x.Id == request.Id).ReturnDate = _dateTimeService.Now;
            await _context.SaveChangesAsync(cancellationToken);
        }
            return Unit.Value;
    }
}
