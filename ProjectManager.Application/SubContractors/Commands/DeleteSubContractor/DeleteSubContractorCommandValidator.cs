using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.SubContractors.Commands.DeleteSubContractor;


public  class DeleteSubContractorCommandValidator: AbstractValidator<DeleteSubContractorCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSubContractorCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
           .NotEmpty()
           .MustAsync(BeEmptySubContractor)
           .WithMessage("Nie można usunąć wybranego podwykonawcy, ponieważ są do niego przypisane zlecenia na projektach. Jeżeli chcesz usunąć wybranego podwykonawcę, to najpierw wypisz go ze wszystkich projektów.");
    }

    private async Task<bool> BeEmptySubContractor(int id, CancellationToken cancellationToken)
    {
        var project = await _context
            .DivisionPositions
            .AsNoTracking()
            .Where(x => x.SubContractorId == id)
            .ToListAsync();
        return !project.Any();  
    }
}
