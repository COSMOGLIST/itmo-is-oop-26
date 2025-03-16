using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record CompareResult
{
    private CompareResult() { }

    public record Incompatible(IEnumerable<string> Errors) : CompareResult;
    public record Compatible() : CompareResult;
    public record CompatibleWithWarning(IEnumerable<string> Warnings) : CompareResult;
}