using FluentValidation;

namespace ProjectManager.Application.Settlements.Commands.EditSettlement;

public class EditSettlementCommandValidator : AbstractValidator<EditSettlementCommand>
{
    public EditSettlementCommandValidator()
    {
        RuleFor(x => x.MarginGen)
           .NotEmpty().WithMessage("Wartość jest wymagana.")
           .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
           .ScalePrecision(2, 2).WithMessage("Wartość mmusi być mniejsza niż 100")
           .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");

        RuleFor(x => x.MarginInstall)
            .NotEmpty().WithMessage("Wartość jest wymagana.")
            .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
            .ScalePrecision(2, 2).WithMessage("Wartość mmusi być mniejsza niż 100")
            .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");

        RuleFor(x => x.Discount)
            .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
            .ScalePrecision(2, 2).WithMessage("Wartość mmusi być mniejsza niż 100")
            .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");

        RuleFor(x => x.CompanyCost)
            .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
            .ScalePrecision(2, 2).WithMessage("Wartość mmusi być mniejsza niż 100")
            .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");

        RuleFor(x => x.CompanyGuarantee)
            .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
            .ScalePrecision(2, 2).WithMessage("Wartość mmusi być mniejsza niż 100")
            .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");

        RuleFor(x => x.Insurance)
            .GreaterThan(0).WithMessage("Wartość musi być większa od zera.")
            .ScalePrecision(2, 2).WithMessage("Wartość mmusi być mniejsza niż 100")
            .WithMessage("Wartość może mieć maksymalnie 2 miejsca po przecinku.");

        RuleFor(x => x.Maturity)
            .NotNull().WithMessage("Wartość jest wymagana.")
            .GreaterThanOrEqualTo(1).WithMessage("Wartość musi być większa lub równa 1.")
            .LessThanOrEqualTo(1000).WithMessage("Wartość nie może przekraczać 1000.");
    }
}
