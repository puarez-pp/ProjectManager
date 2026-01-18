using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Tools.Commands.AddTool;

public class AddToolCommandHandler : IRequestHandler<AddToolCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddToolCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(AddToolCommand request, CancellationToken cancellationToken)
    {
        var tool = new Tool
        {
            Name = request.Name,
            SerialNumber = request.SerialNumber,
            Manufacturer = request.Manufacturer,
            ToolStatus = request.ToolStatus,
            DateOfPurchase = request.DateOfPurchase,
            ValidDate = request.ValidDate
        };
        await _context.Tools.AddAsync(tool);
        await _context.SaveChangesAsync(cancellationToken); 
        return tool.Id;
    }
}
