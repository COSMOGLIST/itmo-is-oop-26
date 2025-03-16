namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public record ReadResult
{
    private ReadResult() { }

    public record ReadSuccess() : ReadResult;

    public record AlreadyRead() : ReadResult;
}