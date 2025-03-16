using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.OutputModes;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeListArgumentHandlers.OutputModeTreeListHandlers;

public class ConsoleOutputModeTreeListHandler : AbstractOutputModeTreeListHandler
{
    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, TreeListArguments.Builder builder)
    {
        if (commandText.Current == "console")
        {
            builder.WithOutputMode(new ConsoleOutputMode());
            return new ArgumentHandlerResult.SuccessResult();
        }
        else
        {
            return base.Handle(commandText, builder);
        }
    }
}