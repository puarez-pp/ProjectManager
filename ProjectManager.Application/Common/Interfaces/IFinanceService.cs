namespace ProjectManager.Application.Common.Interfaces;

public interface IFinanceService
{
    decimal ConvertToEuro(decimal amount, decimal rate);
    decimal ConvertFromEuro(decimal euroAmount, decimal rate);
    decimal CalculateGrossAmount(decimal netAmount, decimal rate);
    decimal CalculateNetAmount(decimal grossAmount, decimal rate);
    decimal ApplyDiscount(decimal amount, decimal discountRate);
    decimal ApplyMargin(decimal amount, decimal marginRate);
    decimal CalculateSumAmounts(IEnumerable<decimal> amounts);
    decimal CalculateDifferenceAmounts(decimal amount1, decimal amount2);
    decimal RoundAmount(decimal amount);
}
