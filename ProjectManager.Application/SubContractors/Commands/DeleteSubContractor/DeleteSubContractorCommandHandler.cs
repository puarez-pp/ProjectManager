using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.SubContractors.Commands.DeleteSubContractor;

public class DeleteSubContractorCommandHandler : IRequestHandler<DeleteSubContractorCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSubContractorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteSubContractorCommand request, CancellationToken cancellationToken)
    {
        var subContractor = await _context
            .SubContractors
            .AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id == request.Id);
        if (subContractor != null)
        {
            _context.SubContractors.Remove(subContractor);
            await _context.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
