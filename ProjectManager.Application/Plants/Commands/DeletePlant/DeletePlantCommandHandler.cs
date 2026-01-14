using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Plants.Commands.DeletePlant;

public class DeletePlantCommandHandler : IRequestHandler<DeletePlantCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePlantCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeletePlantCommand request, CancellationToken cancellationToken)
    {
        var plant = await _context
            .Plants
            .FirstOrDefaultAsync(x => x.Id == request.Id);


        if (plant != null)
        {
            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
