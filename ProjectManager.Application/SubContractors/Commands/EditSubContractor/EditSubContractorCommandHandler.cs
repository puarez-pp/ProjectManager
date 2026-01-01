using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.SubContractors.Commands.EditSubContractor;

public class EditSubContractorCommandHandler : IRequestHandler<EditSubContractorCommand>
{
    private readonly IApplicationDbContext _context;

    public EditSubContractorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditSubContractorCommand request, CancellationToken cancellationToken)
    {
        var subContractor = await _context
            .SubContractors
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        subContractor.Name = request.Name;
        subContractor.ContactPerson = request.ContactPerson;
        subContractor.Email = request.Email;
        subContractor.PhoneNumber = request.PhoneNumber;
        subContractor.City = request.City;
        subContractor.Street = request.Street;
        subContractor.StreetNumber = request.StreetNumber;
        subContractor.ZipCode = request.ZipCode;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
