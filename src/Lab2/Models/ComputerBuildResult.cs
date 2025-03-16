using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record ComputerBuildResult
{
    private ComputerBuildResult() { }
    public record NotSuccessfulBuild(IEnumerable<string> Errors) : ComputerBuildResult;
    public record SuccessfulBuild(Computer Computer) : ComputerBuildResult;
    public record SuccessfulBuildWithWarning(Computer Computer, IEnumerable<string> Warnings) : ComputerBuildResult;
}