using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

[SuppressMessage("Test", "CA1707", Justification = "Test method naming convention")]
public class TestLab4
{
    [Theory]
    [MemberData(nameof(DataForTestGenerator.DataForTest), MemberType = typeof(DataForTestGenerator))]
    public void CreateCommand_ShouldCreateCorrectCommand(string command, Type commandType)
    {
        var chain = new Chain();
        HandlerResult handlerResult = chain.Handle(command.Split());
        Assert.Equal(typeof(HandlerResult.CreatedCommandResult), handlerResult.GetType());
        if (handlerResult is HandlerResult.CreatedCommandResult commandResult)
        {
            Assert.Equal(commandType, commandResult.Command.GetType());
        }
    }
}