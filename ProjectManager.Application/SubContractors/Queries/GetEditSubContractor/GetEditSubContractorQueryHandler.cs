using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.SubContractors.Commands.EditSubContractor;
using ProjectManager.Application.SubContractors.Extension;

namespace ProjectManager.Application.SubContractors.Queries.GetEditSubContractor;

public class GetEditSubContractorQueryHandler : IRequestHandler<GetEditSubContractorQuery, EditSubContractorCommand>
{
    private readonly IApplicationDbContext _context;

    public GetEditSubContractorQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EditSubContractorCommand> Handle(GetEditSubContractorQuery request, CancellationToken cancellationToken)
    {
        var subContractor = (await _context
            .SubContractors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id))
            .ToEditSubContractorCommand();
        return subContractor;
    }
}
