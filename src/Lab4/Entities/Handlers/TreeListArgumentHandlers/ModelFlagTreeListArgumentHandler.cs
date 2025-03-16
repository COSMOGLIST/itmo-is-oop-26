using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeListArgumentHandlers.OutputModeTreeListHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.TreeListArgumentHandlers;

public class ModelFlagTreeListArgumentHandler : AbstractFlagsTreeListArgumentHandler
{
    private readonly IOutputModeTreeListHandler _outputModeTreeHandler;

    public ModelFlagTreeListArgumentHandler(IOutputModeTreeListHandler outputModeTreeHandler)
    {
        _outputModeTreeHandler = outputModeTreeHandler;
    }

    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, TreeListArguments.Builder builder)
    {
        if (commandText.Current == "-m" && commandText.MoveNext())
        {
            return _outputModeTreeHandler.Handle(commandText, builder);
        }
        else
        {
            return base.Handle(commandText, builder);
        }
    }
}