using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Tools.Commands.EditTool;

public class EditToolCommandHandler : IRequestHandler<EditToolCommand>
{
    private readonly IApplicationDbContext _context;

    public EditToolCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await _context.Tools
            .FirstOrDefaultAsync(t => t.Id == request.Id);
        if (tool != null)
        {
            tool.Name = request.Name;
            tool.SerialNumber = request.SerialNumber;
            tool.Manufacturer = request.Manufacturer;
            tool.ToolStatus = request.ToolStatus;
            tool.DateOfPurchase = request.DateOfPurchase;
            tool.ValidDate = request.ValidDate;
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
