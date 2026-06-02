using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

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
        var subContractor = new SubContractor();
        subContractor.Name = request.Name;
        subContractor.ContactPerson = request.ContactPerson;
        subContractor.Email = request.Email;
        subContractor.PhoneNumber = request.PhoneNumber;
        await _context.SubContractors.AddAsync(subContractor);
        subContractor.Address = new SubConAddress
        {
            City = request.City,
            Street = request.Street,
            StreetNumber = request.StreetNumber,
            ZipCode = request.ZipCode
        };
        await _context.SubConAddresses.AddAsync(subContractor.Address);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
        
    }
}
