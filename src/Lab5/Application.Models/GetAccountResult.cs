namespace Application.Models;

public record GetAccountResult
{
    private GetAccountResult() { }

    public sealed record Success(User User) : GetAccountResult;

    public sealed record NoSuchUser() : GetAccountResult;
}