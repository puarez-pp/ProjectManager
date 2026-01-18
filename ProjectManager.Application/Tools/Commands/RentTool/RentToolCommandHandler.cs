using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Tools.RentTool.Commands;

public class RentToolCommandHandler : IRequestHandler<RentToolCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeService _dateTimeService;

    public RentToolCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUserService,
        IDateTimeService dateTimeService
        )
    {
        _context = context;
        _currentUserService = currentUserService;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(RentToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await _context
            .Tools
            .FirstOrDefaultAsync(x=> x.Id == request.Id, cancellationToken);
        if (tool != null && tool.ToolStatus == ToolStatus.Available)
        {
            tool.ToolStatus = ToolStatus.Borrowed;
            await _context.Rents.AddAsync(new ToolRent
            {
                ToolId = request.Id,
                UserId = _currentUserService.UserId,
                RentDate = _dateTimeService.Now
            }, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
