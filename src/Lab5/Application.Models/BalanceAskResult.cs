namespace Application.Models;

public record BalanceAskResult
{
    private BalanceAskResult() { }

    public sealed record Success(decimal AmountOfMoney) : BalanceAskResult;

    public sealed record NotSuccess() : BalanceAskResult;
}