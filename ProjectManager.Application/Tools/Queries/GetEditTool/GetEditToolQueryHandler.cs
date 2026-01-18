using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Tools.Commands.AddTool;
using ProjectManager.Application.Tools.Commands.EditTool;

namespace ProjectManager.Application.Tools.Queries.GetEditTool;

public class GetEditToolQueryHandler : IRequestHandler<GetEditToolQuery, EditToolCommand>
{
    private readonly IApplicationDbContext _context;

    public GetEditToolQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditToolCommand> Handle(GetEditToolQuery request, CancellationToken cancellationToken)
    {

        var tool = await _context.Tools
            .FirstOrDefaultAsync(tool => tool.Id == request.Id, cancellationToken);
        if (tool == null)
        {
            throw new Exception($"Urządzenie nie zostało znalezione.");
        }
        return new EditToolCommand
        {
            Id = tool.Id,
            Name = tool.Name,
            SerialNumber = tool.SerialNumber,
            Manufacturer = tool.Manufacturer,
            ToolStatus = tool.ToolStatus,
            DateOfPurchase = tool.DateOfPurchase,
            ValidDate = tool.ValidDate
        };
    }
}
