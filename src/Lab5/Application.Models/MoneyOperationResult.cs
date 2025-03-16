namespace Application.Models;

public record MoneyOperationResult
{
    private MoneyOperationResult() { }

    public sealed record Success() : MoneyOperationResult;

    public sealed record NoSuchUser() : MoneyOperationResult;

    public sealed record NotEnoughMoney() : MoneyOperationResult;
}