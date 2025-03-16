using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record HandlerResult
{
    private HandlerResult() { }
    public record CreatedCommandResult(ICommand Command) : HandlerResult;

    public record ErrorResult(string ErrorText) : HandlerResult;
}