using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Infrastructure.Services;
  
public class FinanceService : IFinanceService
{
    private const int DecimalPlaces = 2;
    private const MidpointRounding RoundingStrategy = MidpointRounding.AwayFromZero;
    private decimal _amount;

    private decimal RoundAmountTo2Places(decimal amount) => Math.Round(amount, DecimalPlaces, RoundingStrategy);
    public decimal ApplyDiscount(decimal amount, decimal discountRate)
    {
        var amountAfterDiscount = amount - (amount * discountRate / 100);
        return RoundAmountTo2Places(amountAfterDiscount);
    }

    public decimal CalculateGrossAmount(decimal netAmount, decimal rate)
    {
        var grossAmount = netAmount * (1 + rate / 100);
        return RoundAmountTo2Places(grossAmount);
    }

    public decimal CalculateNetAmount(decimal grossAmount, decimal rate)
    {
        var netAmount = grossAmount / (1 + rate / 100);
        return RoundAmountTo2Places(netAmount);
    }


    public decimal ConvertFromEuro(decimal euroAmount, decimal rate)
    {
        return RoundAmountTo2Places(euroAmount * rate);
    }

    public decimal ConvertToEuro(decimal amount, decimal rate)
    {
        if (rate == 0)
        {
            return 0;
        }
        return RoundAmountTo2Places(amount / rate);
    }

    public decimal RoundAmount(decimal amount)
    {
        return RoundAmountTo2Places(amount);
    }

    public decimal ApplyMargin(decimal amount, decimal margintRate)
    {
        return RoundAmountTo2Places(amount + (amount * margintRate / 100));
    }

    public decimal CalculateSumAmounts(IEnumerable<decimal> amounts)
    {
        return RoundAmountTo2Places(amounts.Sum());
    }

    public decimal CalculateDifferenceAmounts(decimal amount1, decimal amount2)
    {
        return RoundAmountTo2Places(amount1 - amount2);
    }

    public decimal CalculatePercentage(decimal amount, decimal rate)
    {
        return RoundAmountTo2Places(amount * rate / 100);
    }

    public decimal CalculateMarginRate(decimal netAmount, decimal grossAmount)
    {
        if (netAmount == 0)
        {
            return 0;
        }
        return RoundAmountTo2Places((grossAmount - netAmount) / netAmount);
    }

    public decimal CalculatePercentageOfRates(decimal amount, IEnumerable<decimal> rates)
    {
        _amount = 0;
        foreach (var rate in rates)
        {
            _amount += rate*amount/100;
        }
        return RoundAmountTo2Places(_amount);
    }

    public decimal CalculatePercentageOfAmounts(decimal rate, IEnumerable<decimal> amounts)
    {
        _amount = 0;
        foreach (var amount in amounts)
        {
            _amount += rate * amount/100;
        }
        return RoundAmountTo2Places(_amount);
    }
}
