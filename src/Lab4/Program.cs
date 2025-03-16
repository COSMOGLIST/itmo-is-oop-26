using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.ErrorsWarningWriters;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var context = new Context(new ConsoleErrorsWarningWriter(), new Symbols("-"));
        while (true)
        {
            string? commandText = Console.ReadLine();
            if (commandText is not null)
            {
                var commands = commandText.Split(' ').ToList();
                HandlerResult handlerResult = new Chain().Handle(commands);
                if (handlerResult is HandlerResult.ErrorResult error)
                {
                    context.ErrorWriter.Write(error.ErrorText);
                }
                else if (handlerResult is HandlerResult.CreatedCommandResult commandResult)
                {
                    commandResult.Command.Execute(context);
                }
            }
        }
    }
}