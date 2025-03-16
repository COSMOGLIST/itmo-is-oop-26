namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record ArgumentHandlerResult
{
    private ArgumentHandlerResult() { }
    public record SuccessResult() : ArgumentHandlerResult;

    public record ErrorResult(string ErrorText) : ArgumentHandlerResult;
}