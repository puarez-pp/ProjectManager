using FluentValidation;

namespace ProjectManager.Application.Settlements.Commands.EditWorkScopeOffer;

public class EditWorkScopeOfferCommandValidator : AbstractValidator<EditWorkScopeOfferCommand>
{
    public EditWorkScopeOfferCommandValidator()
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

        RuleFor(x => x.Quantity)
            .NotNull().WithMessage("Wartość jest wymagana.")
            .GreaterThanOrEqualTo(1).WithMessage("Wartość musi być większa lub równa 1.")
            .LessThanOrEqualTo(1000).WithMessage("Wartość nie może przekraczać 1000.");
    }
}
