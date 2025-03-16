using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.CommandArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileShowArgumentHandlers.OutputModeFileShowHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Handlers.FileShowArgumentHandlers;

public class ModelFlagFileShowArgumentHandler : AbstractFlagsFileShowArgumentHandler
{
    private readonly IOutputModeFileShowHandler _outputModeFileShowHandler;

    public ModelFlagFileShowArgumentHandler(IOutputModeFileShowHandler outputModeFileShowHandler)
    {
        _outputModeFileShowHandler = outputModeFileShowHandler;
    }

    public override ArgumentHandlerResult Handle(IEnumerator<string> commandText, FileShowArguments.Builder builder)
    {
        if (commandText.Current == "-m" && commandText.MoveNext())
        {
            return _outputModeFileShowHandler.Handle(commandText, builder);
        }
        else
        {
            return base.Handle(commandText, builder);
        }
    }
}