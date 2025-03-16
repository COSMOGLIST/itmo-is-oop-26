using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Elements;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public record DirectoryElementResult
{
    private DirectoryElementResult() { }

    public record NoResult() : DirectoryElementResult;
    public record SuccessResult(IElement Element) : DirectoryElementResult;
}