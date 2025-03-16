namespace Application.Models;

public record ConnectAdminResult
{
    private ConnectAdminResult() { }

    public sealed record Success() : ConnectAdminResult;

    public sealed record NotSuccess() : ConnectAdminResult;
}
