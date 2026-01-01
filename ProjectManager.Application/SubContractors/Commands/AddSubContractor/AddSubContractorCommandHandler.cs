using MediatR;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.SubContractors.Commands.AddSubContractor;
public class AddSubContractorCommandHandler : IRequestHandler<AddSubContractorCommand>
{
    private readonly IApplicationDbContext _context;

    public AddSubContractorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(AddSubContractorCommand request, CancellationToken cancellationToken)
    {
        var subContractors = new Domain.Entities.SubContractor();
        subContractors.Name = request.Name;
        subContractors.ContactPerson = request.ContactPerson;
        subContractors.Email = request.Email;
        subContractors.PhoneNumber = request.PhoneNumber;
        subContractors.City = request.City;
        subContractors.Street = request.Street;
        subContractors.StreetNumber = request.StreetNumber;
        subContractors.ZipCode = request.ZipCode;
        await _context.SubContractors.AddAsync(subContractors);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        
    }
}
