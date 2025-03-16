namespace Application.PresentationPort;

public record LogInResult
{
    private LogInResult() { }

    public sealed record Success() : LogInResult;

    public sealed record NoSuccess() : LogInResult;
}