using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Clients.Commands.DeleteClient;


public  class DeleteClientCommandValidator: AbstractValidator<DeleteClientCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteClientCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
           .NotEmpty()
           .MustAsync(BeEmptyClient)
           .WithMessage("Nie można usunąć wybranego klienta, ponieważ są do niego przypisane projekty. Jeżeli chcesz usunąć wybranego klienta, to najpierw wypisz go ze wszystkich projektów.");
    }

    private async Task<bool> BeEmptyClient(int id, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(x => x.ClientId == id)
            .ToListAsync();
        return !project.Any();  
    }
}
