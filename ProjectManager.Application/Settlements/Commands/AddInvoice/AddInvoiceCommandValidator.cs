using FluentValidation;

namespace ProjectManager.Application.Settlements.Commands.AddInvoice;

public class AddInvoiceCommandValidator : AbstractValidator<AddInvoiceCommand>
{
    public AddInvoiceCommandValidator()
    {
        RuleFor(x => x.NetAmount)
           .NotEmpty().WithMessage("Wartość jest wymagana.")
           .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
           .ScalePrecision(10, 2)
           .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");

        RuleFor(x => x.EuroNetAmount)
           .NotEmpty().WithMessage("Wartość jest wymagana.")
           .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
           .ScalePrecision(10, 2)
           .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");

        RuleFor(x => x.EuroRate)
            .NotEmpty().WithMessage("Wartość jest wymagana.")
            .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
            .ScalePrecision(3, 2)
            .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");
    }
}
