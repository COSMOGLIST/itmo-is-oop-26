namespace Application.Models;

public record CreateAccountResult
{
    private CreateAccountResult() { }

    public sealed record Success() : CreateAccountResult;

    public sealed record NotSuccess() : CreateAccountResult;
}